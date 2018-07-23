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
    public partial class customerdetailcs : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public customerdetailcs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            approvel a = new approvel();
            a.Show();
            this.Hide();
        }

        private void customerdetailcs_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into customer_d(cid,cname,address,city,cnic,contact,status,usedfor) VALUES(@cid,@cname,@address,@city,@cnic,@contact,@status,@usedfor)", conn);
            cmd.Parameters.AddWithValue("cid", this.textBox1.Text);
            cmd.Parameters.AddWithValue("cname", this.textBox2.Text);
            cmd.Parameters.AddWithValue("address", this.textBox3.Text);
            cmd.Parameters.AddWithValue("city", this.textBox4.Text);
            cmd.Parameters.AddWithValue("cnic", this.textBox5.Text);
            cmd.Parameters.AddWithValue("contact", this.textBox6.Text);
            cmd.Parameters.AddWithValue("status", this.textBox7.Text);
            cmd.Parameters.AddWithValue("usedfor", this.textBox8.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("ur record has ben inserted");
            conn.Close();
        }
    }
}
