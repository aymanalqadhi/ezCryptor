using System.Windows.Forms;
using System.ComponentModel.Composition;
using System;
using System.IO;
using System.Linq;
using ezCryptor.Forms;
using ezCryptor.Utils;
using System.Text;
using ezCryptor.Shared.Crypto;
using ezCryptor.Shared.Services;
using System.Drawing;

namespace ezCryptor.Controls
{
    [Export(typeof(ICryptoControl))]
    public partial class DecryptionControl : UserControl, ICryptoControl
    {
        #region Private Fields

        /// <summary>
        /// A Service to manage app logs
        /// </summary>
        [Import]
        private ILogger _logger = null;

        /// <summary>
        /// The application progress reporter
        /// </summary>
        [Import]
        IApplicationProgressReporter _progressReporter = null;

        /// <summary>
        /// The backing field of <see cref="SelectedAlgorithm"/>
        /// </summary>
        private ICryptoAlgorithm _selectedAlgorithm;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the title of this control
        /// </summary>
        public string Title => "Decryption";

        /// <summary>
        /// Gets or sets the selected algorithm
        /// </summary>
        public ICryptoAlgorithm SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                startDecryptingBtn.Enabled = CanStartDecrypting;
                _selectedAlgorithm = value;

                startDecryptingBtn.Enabled = CanStartDecrypting;
            }
        }

        /// <summary>
        /// Gets whether the user can start decryption process
        /// </summary>
        public bool CanStartDecrypting => SelectedAlgorithm != null && filesLst.Items.Count > 0;

        /// <summary>
        /// The encryption keysize
        /// </summary>
        public int KeySize { get; set; }

        /// <summary>
        /// The Selected ChunkSize
        /// </summary>
        public uint ChunkSize { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DecryptionControl()
        {
            InitializeComponent();

            /** Add Light Even Handlers **/
            filesLst.ItemChecked += delegate { removeFilesFromListBtn.Enabled = filesLst.CheckedItems.Count > 0; };
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Starts the decryption process
        /// </summary>
        private async void startDecryptingBtn_Click(object sender, EventArgs e)
        {
            var dirDlg = new FolderBrowserDialog { Description = "Select a folder to which the files will be decrypted:" };
            if (dirDlg.ShowDialog() != DialogResult.OK) return;

            var pwdDlg = new EnterPasswordForm();
            if (pwdDlg.ShowDialog() != DialogResult.OK) return;

            _progressReporter.LockUI();
            _progressReporter.Report(-1, "Decrypting Files...");
            SelectedAlgorithm.Key = Utils.Keys.GetKey(pwdDlg.Password, (KeyType)KeySize);

            foreach (ListViewItem file in filesLst.Items)
            {
                file.ForeColor = Color.Gray;

                var fileInfo = new FileInfo(file.SubItems[3].Text);
                if (!fileInfo.Exists)
                {
                    filesLst.Items.Remove(file);
                    continue;
                }

                var decryptedFileInfo = new FileInfo(FileName.GetUnusedFileName(Path.Combine(dirDlg.SelectedPath, Path.GetFileNameWithoutExtension(fileInfo.Name))));

                _logger.Log(LoggingLevel.Information, "Decrypting `" + fileInfo.Name + "`...");
                _progressReporter.Report(-1, "Decrypting `" + fileInfo.Name + "`...");

                using (var from = fileInfo.OpenRead())
                using (var to = decryptedFileInfo.OpenWrite())
                {
                    _logger.Log(LoggingLevel.Information, $"Decrypting {fileInfo.Name}...");
                    var director = new CryptoDirector(SelectedAlgorithm, from, to, RedirectionMode.Decrypt, ChunkSize);

                    try
                    {
                        while (await director.ProcessChunk(
                            p => _progressReporter.Report((int)(p * 100), $"{p * 100:0.00}% | Decrypting {fileInfo.Name}...")
                        ));

                        file.ForeColor = Color.Green;
                        _logger.Log(LoggingLevel.Information, "File `{0}` was decrypted successfully!", fileInfo.Name);
                    }
                    catch (Exception ex)
                    {
                        file.ForeColor = Color.Red;
                        _logger.Log(LoggingLevel.Error, "Could not Decrypt `{0}`!", fileInfo.Name);
                        _logger.Log(LoggingLevel.Trace, ex.Message);

                        if (decryptedFileInfo.Exists)
                        {
                            to.Close();
                            decryptedFileInfo.Delete();
                        }
                    }
                }
            }

            MessageBox.Show($"Decrypted {filesLst.Items.OfType<ListViewItem>().Count(li => li.ForeColor == Color.Green)} Files Out Of {filesLst.Items.Count}!", "Summury", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (ListViewItem item in filesLst.Items)
            {
                if (item.ForeColor == Color.Green)
                {
                    if (!keepOldFilesCheck.Checked) File.Delete(item.SubItems[3].Text);
                    filesLst.Items.Remove(item);
                }
            }

            _progressReporter.Report(0, "Ready");
            _progressReporter.UnlockUI();
        }

        /// <summary>
        /// Adds a group of files to the list
        /// </summary>
        private void addFilesBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "Choose Files To Add To The Decryption List",
                Filter = "EZE Files | *.eze",
                Multiselect = true
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;
            dlg.FileNames.Select(fn => new FileInfo(fn)).ToList().ForEach(AddToDecryptionList);
        }

        /// <summary>
        /// Adds a directory files to the list
        /// </summary>
        private void addDirBtn_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog { Description = "Choose a Directory To Add Its Files To The Decryption List" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            new DirectoryInfo(dlg.SelectedPath).GetFiles().Where(fn => fn.Extension == ".eze").ToList().ForEach(AddToDecryptionList);
        }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        private void removeFilesFromListBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in filesLst.CheckedItems)
                filesLst.Items.Remove(item);
            startDecryptingBtn.Enabled = CanStartDecrypting;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// A Helper method to add a file entry to to-decrypt the files list
        /// </summary>
        /// <param name="fileInfo">The file to add</param>
        private void AddToDecryptionList(FileInfo fileInfo)
        {
            filesLst.Items.Add(new ListViewItem(new[] { Path.GetFileNameWithoutExtension(fileInfo.Name), fileInfo.Extension.TrimStart('.') + " File", fileInfo.Length + " Bytes", fileInfo.FullName }));
            _logger.Log(LoggingLevel.Debug, "Added File {0} To Decryption List", fileInfo.Name);
            startDecryptingBtn.Enabled = CanStartDecrypting;
        }

        #endregion
    }
}
