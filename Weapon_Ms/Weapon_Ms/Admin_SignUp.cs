using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Weapon_Ms
{
    public partial class Admin_SignUp : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn=new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public Admin_SignUp()
        {
            InitializeComponent();
        }

        private void Admin_SignUp_Load(object sender, EventArgs e)
        {
            this.label1.Text = "SingUp";
            this.label2.Text = "User Name";
            this.label3.Text = "Passwrd";
            this.button1.Text = "Reset";
            this.button2.Text = "SignUp";
            this.button3.Text = "Back";
           
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Login li = new Login();
            li.Show();
            this.Hide();
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into user_d(name,password) VALUES(@name,@password)", conn);
            cmd.Parameters.AddWithValue("name", this.textBox1.Text);
            cmd.Parameters.AddWithValue("password", this.textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("ur record has ben inserted");
            conn.Close();
        }
    }
}
