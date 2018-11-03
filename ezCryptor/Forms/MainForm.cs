using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using ezCryptor.Shared.Crypto;
using ezCryptor.Shared.Services;
using System.Text.RegularExpressions;

namespace ezCryptor.Forms
{
    public partial class MainForm : Form
    {
        #region Private Fields

        /// <summary>
        /// The main app object
        /// </summary>
        private readonly App _app;

        /// <summary>
        /// A DI service to manage app logs
        /// </summary>
        [Import] private ILogger _logger = null;

        /// <summary>
        /// The application progress reporter handlers
        /// </summary>
        [Import] private IApplicationProgressReporter _progressReporter = null;

        /// <summary>
        /// All alogrithms exported by the app
        /// </summary>
        [ImportMany] private IEnumerable<ICryptoAlgorithm> _algorithms = null;

        /// <summary>
        /// All controls exported by the app
        /// </summary>
        [ImportMany] private IEnumerable<ICryptoControl> _controls = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Initialize Private fields
            _app = new App();
            
            // Disable the UI
            mainTabControl.Enabled = false;
            mainMenu.Enabled = false;

            /// Light Event Handlers
            algorithmsCombo.SelectedValueChanged += delegate 
            {
                var selectedAlgorithm = (ICryptoAlgorithm)algorithmsCombo.SelectedItem;

                foreach (var control in _controls)
                {
                    control.SelectedAlgorithm = selectedAlgorithm;
                    control.KeySize = selectedAlgorithm.DefaultKeySize;
                }

                keySizeCombo.Items.Clear();
                selectedAlgorithm.SupportedKeySizes.ToList().ForEach(ksz => keySizeCombo.Items.Add(ksz));
            };

            keySizeCombo.SelectedIndexChanged += delegate
            {
                if (algorithmsCombo.SelectedItem == null) return;

                foreach (var control in _controls)
                {
                    int keysize = ((ICryptoAlgorithm)algorithmsCombo.SelectedItem).DefaultKeySize;
                    int.TryParse(keySizeCombo.SelectedItem?.ToString(), out keysize);
                    control.KeySize = keysize;
                }
            };

            chunkSizeCombo.TextChanged += delegate
            {
                foreach (var control in _controls)
                    control.ChunkSize = uint.Parse(chunkSizeCombo.Text);
            };

            aboutToolBtn.Click += delegate { new About().ShowDialog(); };
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Executes when the form loads
        /// </summary>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize app
            if (!await _app.Initialize(ReportProgress))
            {
                Console.WriteLine("FATAL: Could not initialize the application!");
                MessageBox.Show("Could not initialize the application!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            _app.CompositionService.SatisfyImportsOnce(this);
            _progressReporter.ProgressUpdated += (ss, ee) => ReportProgress(ee.Item1, ee.Item2);
            _progressReporter.UILockRequested += (ss, ee) => mainTabControl.Enabled = !ee;

            _logger.AddOutputStreams(Console.OpenStandardOutput());
            _logger.Log(LoggingLevel.Information, "App Initialized Successully!");

            // Initialize algorithms
            _algorithms.ToList().ForEach(async alg =>
            {
                if (await alg.Initialize())
                {
                    _logger.Log(LoggingLevel.Information, "Initialized Algorithm {0}", alg.Name);
                    algorithmsCombo.Items.Add(alg);
                }
                else
                    _logger.Log(LoggingLevel.Information, "Couldn't Initialize Algorithm {0}", alg.Name);
            });

            // Load Controls
            _controls.Where(c => c is UserControl).ToList().ForEach(c =>
            {
                var page = new TabPage { Text = c.Title };
                var cont = (UserControl)c;
                cont.Dock = DockStyle.Fill;

                page.Controls.Add(cont);
                mainTabControl.TabPages.Add(page);
            });

            #region Make UI Ready
            mainTabControl.Enabled = mainMenu.Enabled = true;
            ReportProgress(0, "Ready");
            chunkSizeCombo.SelectedIndex = chunkSizeCombo.Items.Count - 1;
            #endregion
        }

        #endregion
        
        #region Helper Methods

        /// <summary>
        /// Sets the current application progress
        /// </summary>
        /// <param name="progress">The progress pair</param>
        private void ReportProgress(int value, string captions)
            => BeginInvoke(new Action(() =>
               {
                   if (value < 0) mainProgressBar.Style = ProgressBarStyle.Marquee;
                   else
                   {
                       mainProgressBar.Style = ProgressBarStyle.Blocks;
                       mainProgressBar.ProgressBar.Value = value % 100;
                   }
                   mainStatus.Text = captions;
               }
            )
        );

        #endregion
    }
}