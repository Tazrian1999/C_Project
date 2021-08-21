using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retry_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="tushti" && textBox2.Text=="1234")
            {
                MessageBox.Show("Login Successful", "Succeeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard d1 = new Dashboard();
                d1.Show();
                this.Hide();
                
            }
        }
  
    }
}
