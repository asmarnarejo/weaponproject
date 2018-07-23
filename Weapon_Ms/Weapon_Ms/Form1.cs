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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.label1.Text = "          Weapons" + Environment.NewLine + "Management System";
            this.button1.Text = "Welcome";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login Lg= new Login();
            Lg.Show();
            this.Hide();

        }
    }
}
