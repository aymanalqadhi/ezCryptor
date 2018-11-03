using System.Windows.Forms;
using System;
using ezCryptor.Forms;
using ezCryptor.Utils;
using System.Text;
using System.Drawing;
using System.IO;
using System.ComponentModel.Composition;
using System.Linq;
using ezCryptor.Shared.Crypto;
using ezCryptor.Shared.Services;

namespace ezCryptor.Controls
{
    [Export(typeof(ICryptoControl))]
    public partial class EncryptionControl : UserControl, ICryptoControl
    {
        #region Private Fields
        
        /// <summary>
        /// A Service to manage app logs
        /// </summary>
        [Import] private ILogger _logger = null;

        /// <summary>
        /// The application progress reporter
        /// </summary>
        [Import] private IApplicationProgressReporter _progressReporter = null;

        /// <summary>
        /// The backing field of <see cref="SelectedAlgorithm"/>
        /// </summary>
        private ICryptoAlgorithm _selectedAlgorithm;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the title of this control
        /// </summary>
        public string Title => "Encryption";

        /// <summary>
        /// Gets or sets the selected algorithm
        /// </summary>
        public ICryptoAlgorithm SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                startEncryptingBtn.Enabled = CanStartEncrypting;
                _selectedAlgorithm = value;

                startEncryptingBtn.Enabled = CanStartEncrypting;
            }
        }

        /// <summary>
        /// Gets whether the user can start decryption process
        /// </summary>
        public bool CanStartEncrypting => SelectedAlgorithm != null && filesLst.Items.Count > 0;


        /// <summary>
        /// The encryption keysize
        /// </summary>
        public int KeySize { get; set; }

        /// <summary>
        /// The Selected Chunksize
        /// </summary>
        public uint ChunkSize { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EncryptionControl()
        {
            InitializeComponent();

            /** Initialize Light event handlers **/
            filesLst.ItemChecked += delegate { removeFileFromEncryptionLst.Enabled = filesLst.CheckedItems.Count > 0; };
        }

        #endregion

        #region Events Handlers
        
        /// <summary>
        /// Starts The encryption process
        /// </summary>
        private async void startEncryptingBtn_Click(object sender, EventArgs e)
        {
            var dirDlg = new FolderBrowserDialog { Description = "Select a folder to which the files will be encrypted:" };
            if (dirDlg.ShowDialog() != DialogResult.OK) return;

            var pwdDlg = new ChoosePasswordForm();
            if (pwdDlg.ShowDialog() != DialogResult.OK) return;

            _progressReporter.LockUI();
            _progressReporter.Report(-1, "Encrypting Files...");
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

                var encryptedFileInfo = new FileInfo(FileName.GetUnusedFileName(Path.Combine(dirDlg.SelectedPath, fileInfo.Name) + ".eze"));

                using (var from = fileInfo.OpenRead())
                using (var to = encryptedFileInfo.OpenWrite())
                {
                    _logger.Log(LoggingLevel.Information, $"Encrypting {fileInfo.Name}...");
                    var director = new CryptoDirector(SelectedAlgorithm, from, to, RedirectionMode.Encrypt, ChunkSize);
                    try
                    {
                        while (await director.ProcessChunk(
                            p => _progressReporter.Report((int)(p * 100), $"{p * 100:0.00}% | Encrypting {fileInfo.Name}...")
                        ))
                            ;

                        file.ForeColor = Color.Green;
                        _logger.Log(LoggingLevel.Information, "File `{0}` was encrypted successfully!", fileInfo.Name);
                    }
                    catch (Exception ex)
                    {
                        file.ForeColor = Color.Red;
                        _logger.Log(LoggingLevel.Error, "Could not encrypt `{0}`!", fileInfo.Name);
                        _logger.Log(LoggingLevel.Trace, ex.Message);

                        if (encryptedFileInfo.Exists)
                        {
                            to.Close();
                            encryptedFileInfo.Delete();
                        }
                    }
                }
            }

            MessageBox.Show(
                $"Encrypted {filesLst.Items.OfType<ListViewItem>().Count(li => li.ForeColor == Color.Green)} Files Out Of {filesLst.Items.Count}",
                "Summury", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

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

        /// <summary>s
        /// Adds file to the files list
        /// </summary>
        private void addFilesBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "Choose Files To Add To The Encryption List",
                Filter = "All Files | *.*",
                Multiselect = true
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;
            dlg.FileNames.Select(fn => new FileInfo(fn)).ToList().ForEach(AddToEncryptionList);
        }

        /// <summary>
        /// Add a directory files to the files list
        /// </summary>
        private void addDirBtn_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog { Description = "Choose a Directory To Add Its Files To The Encryption List" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            new DirectoryInfo(dlg.SelectedPath).GetFiles().ToList().ForEach(AddToEncryptionList);
        }

        /// <summary>
        /// Removes an item from the encryption list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeFileFromEncryptionLst_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in filesLst.CheckedItems)
                filesLst.Items.Remove(item);
            startEncryptingBtn.Enabled = CanStartEncrypting;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// A Helper method to add a file entry to the to-encrypt files list
        /// </summary>
        /// <param name="fileInfo">The file to add</param>
        private void AddToEncryptionList(FileInfo fileInfo)
        {
            filesLst.Items.Add(new ListViewItem(new[] { Path.GetFileNameWithoutExtension(fileInfo.Name), fileInfo.Extension.TrimStart('.') + " File", fileInfo.Length + " Bytes", fileInfo.FullName }));
            _logger.Log(LoggingLevel.Debug, "Added File {0} To Encryption List", fileInfo.Name);
            startEncryptingBtn.Enabled = CanStartEncrypting;
        }

        #endregion
    }
}
