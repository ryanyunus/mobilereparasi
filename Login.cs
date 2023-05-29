using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobilereparasi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();     
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }else if(UnameTb.Text == "Admin" || PasswordTb.Text == "Admin")
             {
                RepDateTb Obj = new RepDateTb();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password or Username!!!");
            }
        }
    }
}
