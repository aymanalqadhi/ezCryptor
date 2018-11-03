namespace ezCryptor.Forms
{
    partial class ChoosePasswordForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.paawordTxt = new System.Windows.Forms.TextBox();
            this.confirmKeyTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.passwordStrengthLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.panel1.Size = new System.Drawing.Size(260, 28);
            this.panel1.TabIndex = 7;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelBtn.Location = new System.Drawing.Point(105, 0);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "&CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.okBtn.Enabled = false;
            this.okBtn.Location = new System.Drawing.Point(180, 0);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "&OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // paawordTxt
            // 
            this.paawordTxt.Location = new System.Drawing.Point(78, 11);
            this.paawordTxt.MaxLength = 32;
            this.paawordTxt.Name = "paawordTxt";
            this.paawordTxt.Size = new System.Drawing.Size(177, 20);
            this.paawordTxt.TabIndex = 6;
            this.paawordTxt.UseSystemPasswordChar = true;
            this.paawordTxt.TextChanged += new System.EventHandler(this.keyTxt_TextChanged);
            // 
            // confirmKeyTxt
            // 
            this.confirmKeyTxt.Location = new System.Drawing.Point(78, 37);
            this.confirmKeyTxt.MaxLength = 32;
            this.confirmKeyTxt.Name = "confirmKeyTxt";
            this.confirmKeyTxt.Size = new System.Drawing.Size(177, 20);
            this.confirmKeyTxt.TabIndex = 7;
            this.confirmKeyTxt.UseSystemPasswordChar = true;
            this.confirmKeyTxt.TextChanged += new System.EventHandler(this.confirmKeyTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirm Key:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.confirmKeyTxt);
            this.panel2.Controls.Add(this.paawordTxt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 62);
            this.panel2.TabIndex = 9;
            // 
            // passwordStrengthLbl
            // 
            this.passwordStrengthLbl.AutoSize = true;
            this.passwordStrengthLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.passwordStrengthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStrengthLbl.ForeColor = System.Drawing.Color.Green;
            this.passwordStrengthLbl.Location = new System.Drawing.Point(255, 62);
            this.passwordStrengthLbl.Name = "passwordStrengthLbl";
            this.passwordStrengthLbl.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.passwordStrengthLbl.Size = new System.Drawing.Size(5, 16);
            this.passwordStrengthLbl.TabIndex = 10;
            this.passwordStrengthLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.passwordStrengthLbl.UseCompatibleTextRendering = true;
            // 
            // ChoosePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 110);
            this.Controls.Add(this.passwordStrengthLbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoosePasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose a key";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox paawordTxt;
        private System.Windows.Forms.TextBox confirmKeyTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label passwordStrengthLbl;
    }
}