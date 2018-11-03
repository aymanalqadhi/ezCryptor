using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ezCryptor.Forms
{
    public partial class EnterPasswordForm : Form
    {
        public EnterPasswordForm()
        {
            InitializeComponent();

            showInClearChk.CheckedChanged += (s, e) => passwordTxt.UseSystemPasswordChar = !showInClearChk.Checked;
            passwordTxt.TextChanged += (s, e) => okBtn.Enabled = passwordTxt.TextLength >= 8;
        }

        /// <summary>
        /// Selected Password
        /// </summary>
        public string Password => passwordTxt.Text;
    }
}
