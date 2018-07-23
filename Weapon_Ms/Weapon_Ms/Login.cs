using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Weapon_Ms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.label1.Text = "        Weapons" + Environment.NewLine + "Management System";
            this.button1.Text = "SingUp";
            this.button2.Text = "SingIn";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_SignUp su = new Admin_SignUp();
            su.Show();
            this.Hide();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {

            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }
    }
}
