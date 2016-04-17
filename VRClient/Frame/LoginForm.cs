using CCWin;
using System;
using System.Windows.Forms;

namespace VRClient
{
    public partial class LoginForm : CCSkinMain
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
