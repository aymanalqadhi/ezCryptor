namespace ezCryptor.Controls
{
    partial class EncryptionControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.removeFileFromEncryptionLst = new System.Windows.Forms.Button();
            this.keepOldFilesCheck = new System.Windows.Forms.CheckBox();
            this.addDirBtn = new System.Windows.Forms.Button();
            this.addFilesBtn = new System.Windows.Forms.Button();
            this.startEncryptingBtn = new System.Windows.Forms.Button();
            this.filesLst = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.removeFileFromEncryptionLst);
            this.panel2.Controls.Add(this.keepOldFilesCheck);
            this.panel2.Controls.Add(this.addDirBtn);
            this.panel2.Controls.Add(this.addFilesBtn);
            this.panel2.Controls.Add(this.startEncryptingBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 29);
            this.panel2.TabIndex = 20;
            // 
            // removeFileFromEncryptionLst
            // 
            this.removeFileFromEncryptionLst.Dock = System.Windows.Forms.DockStyle.Left;
            this.removeFileFromEncryptionLst.Enabled = false;
            this.removeFileFromEncryptionLst.FlatAppearance.BorderSize = 0;
            this.removeFileFromEncryptionLst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeFileFromEncryptionLst.ForeColor = System.Drawing.Color.Red;
            this.removeFileFromEncryptionLst.Location = new System.Drawing.Point(196, 0);
            this.removeFileFromEncryptionLst.Name = "removeFileFromEncryptionLst";
            this.removeFileFromEncryptionLst.Size = new System.Drawing.Size(28, 29);
            this.removeFileFromEncryptionLst.TabIndex = 11;
            this.removeFileFromEncryptionLst.Text = "X";
            this.removeFileFromEncryptionLst.UseVisualStyleBackColor = true;
            this.removeFileFromEncryptionLst.Click += new System.EventHandler(this.removeFileFromEncryptionLst_Click);
            // 
            // keepOldFilesCheck
            // 
            this.keepOldFilesCheck.AutoSize = true;
            this.keepOldFilesCheck.Checked = true;
            this.keepOldFilesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keepOldFilesCheck.Dock = System.Windows.Forms.DockStyle.Right;
            this.keepOldFilesCheck.Location = new System.Drawing.Point(268, 0);
            this.keepOldFilesCheck.Name = "keepOldFilesCheck";
            this.keepOldFilesCheck.Size = new System.Drawing.Size(94, 29);
            this.keepOldFilesCheck.TabIndex = 10;
            this.keepOldFilesCheck.Text = "Keep Old Files";
            this.keepOldFilesCheck.UseVisualStyleBackColor = true;
            // 
            // addDirBtn
            // 
            this.addDirBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.addDirBtn.Location = new System.Drawing.Point(98, 0);
            this.addDirBtn.Name = "addDirBtn";
            this.addDirBtn.Size = new System.Drawing.Size(98, 29);
            this.addDirBtn.TabIndex = 9;
            this.addDirBtn.Text = "Add &Directory";
            this.addDirBtn.UseVisualStyleBackColor = true;
            this.addDirBtn.Click += new System.EventHandler(this.addDirBtn_Click);
            // 
            // addFilesBtn
            // 
            this.addFilesBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.addFilesBtn.Location = new System.Drawing.Point(0, 0);
            this.addFilesBtn.Name = "addFilesBtn";
            this.addFilesBtn.Size = new System.Drawing.Size(98, 29);
            this.addFilesBtn.TabIndex = 8;
            this.addFilesBtn.Text = "&Add Files";
            this.addFilesBtn.UseVisualStyleBackColor = true;
            this.addFilesBtn.Click += new System.EventHandler(this.addFilesBtn_Click);
            // 
            // startEncryptingBtn
            // 
            this.startEncryptingBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.startEncryptingBtn.Enabled = false;
            this.startEncryptingBtn.Location = new System.Drawing.Point(362, 0);
            this.startEncryptingBtn.Name = "startEncryptingBtn";
            this.startEncryptingBtn.Size = new System.Drawing.Size(98, 29);
            this.startEncryptingBtn.TabIndex = 7;
            this.startEncryptingBtn.Text = "&Start Encrypting";
            this.startEncryptingBtn.UseVisualStyleBackColor = true;
            this.startEncryptingBtn.Click += new System.EventHandler(this.startEncryptingBtn_Click);
            // 
            // filesLst
            // 
            this.filesLst.CheckBoxes = true;
            this.filesLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.typeColumn,
            this.sizeColumn,
            this.fullNameColumn});
            this.filesLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesLst.FullRowSelect = true;
            this.filesLst.Location = new System.Drawing.Point(0, 0);
            this.filesLst.Name = "filesLst";
            this.filesLst.Size = new System.Drawing.Size(460, 278);
            this.filesLst.TabIndex = 19;
            this.filesLst.UseCompatibleStateImageBehavior = false;
            this.filesLst.View = System.Windows.Forms.View.Details;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 239;
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            this.typeColumn.Width = 97;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            this.sizeColumn.Width = 156;
            // 
            // fullNameColumn
            // 
            this.fullNameColumn.Text = "Full Name";
            this.fullNameColumn.Width = 0;
            // 
            // EncryptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.filesLst);
            this.Name = "EncryptionControl";
            this.Size = new System.Drawing.Size(460, 278);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removeFileFromEncryptionLst;
        private System.Windows.Forms.CheckBox keepOldFilesCheck;
        private System.Windows.Forms.Button addDirBtn;
        private System.Windows.Forms.Button addFilesBtn;
        private System.Windows.Forms.Button startEncryptingBtn;
        private System.Windows.Forms.ListView filesLst;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader fullNameColumn;
    }
}
