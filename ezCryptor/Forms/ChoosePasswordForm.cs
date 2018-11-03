using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ezCryptor.Forms
{
    public partial class ChoosePasswordForm : Form
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChoosePasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks the password validity and strength
        /// </summary>
        private void keyTxt_TextChanged(object sender, EventArgs e)
        {
            if (paawordTxt.TextLength < 8)
            {
                passwordStrengthLbl.Text = "Too Short";
                passwordStrengthLbl.ForeColor = Color.Red;
                CanProceed = false;
            }
            else if ((paawordTxt.Text.All(c => char.IsDigit(c)) || paawordTxt.Text.All(c => char.IsLetter(c))) && paawordTxt.TextLength < 16)
            {
                passwordStrengthLbl.Text = "Very Weak";
                passwordStrengthLbl.ForeColor = Color.Yellow;
                CanProceed = true;
            }
            else if (!paawordTxt.Text.Any(c => char.IsDigit(c)))
            {
                passwordStrengthLbl.Text = "Weak";
                passwordStrengthLbl.ForeColor = Color.Gold;
                CanProceed = true;
            }
            else if (!paawordTxt.Text.Any(c => char.IsUpper(c)))
            {
                passwordStrengthLbl.Text = "Weak";
                passwordStrengthLbl.ForeColor = Color.Gold;
                CanProceed = true;
            }
            else
            {
                passwordStrengthLbl.Text = "Strong";
                passwordStrengthLbl.ForeColor = Color.Green;
                CanProceed = true;
            }

            okBtn.Enabled = CanProceed && (paawordTxt.Text == confirmKeyTxt.Text);
        }

        /// <summary>
        /// Handles the confirmation text box input
        /// </summary>
        private void confirmKeyTxt_TextChanged(object sender, EventArgs e)
        {
            if (paawordTxt.Text != confirmKeyTxt.Text)
            {
                passwordStrengthLbl.Text = "Passwords Do Not Match!";
                passwordStrengthLbl.ForeColor = Color.DarkRed;
            }
            else
                keyTxt_TextChanged(null, null);
        }

        /// <summary>
        /// Gets whether that the user has entered a valid password
        /// </summary>
        private bool CanProceed { get; set; }

        /// <summary>
        /// Gets the selected key string
        /// </summary>
        public string Password => paawordTxt.Text;
    }
}
