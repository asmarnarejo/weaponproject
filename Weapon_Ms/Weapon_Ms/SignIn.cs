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
    public partial class SignIn : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public SignIn()
        {

            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Admin Login";
            this.label2.Text = "User Name";
            this.label3.Text = "Passwrd";
            this.button1.Text = "Reset";
            this.button2.Text = "login";
            this.button3.Text = "Back";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login li = new Login();
            li.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox1.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from user_d where name='" + textBox1.Text + "' and password='" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                customerdetailcs cd = new customerdetailcs();
                cd.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("invalid user or password");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}