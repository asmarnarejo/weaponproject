using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Weapon_Ms
{
    public partial class DISAPPROVE : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public DISAPPROVE()
        {
            InitializeComponent();
        }

        private void DISAPPROVE_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select cid from customer_d", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cid"].ToString());
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            approvel a = new approvel();
            a.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from customer_d where cid='" + comboBox1.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["cname"].ToString();
                textBox2.Text = dr["address"].ToString();
                textBox3.Text = dr["city"].ToString();
                textBox4.Text = dr["cnic"].ToString();
                textBox5.Text = dr["contact"].ToString();
                textBox6.Text = dr["status"].ToString();
                textBox7.Text = dr["usedfor"].ToString();

            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        
        {
            conn.Open();
            cmd = new SqlCommand("Update customer_d set cname=@cname,address=@address,city=@city,cnic=@cnic,contact=@contact,status=@status,usedfor=@usedfor where cid=@cid ", conn);

            cmd.Parameters.AddWithValue("@cname", textBox1.Text);
            cmd.Parameters.AddWithValue("@address", textBox2.Text);
            cmd.Parameters.AddWithValue("@city", textBox3.Text);
            cmd.Parameters.AddWithValue("@cnic", textBox4.Text);
            cmd.Parameters.AddWithValue("@contact", textBox5.Text);
            cmd.Parameters.AddWithValue("@status", textBox6.Text);
            cmd.Parameters.AddWithValue("@usedfor", textBox7.Text);
            cmd.Parameters.AddWithValue("@cid", comboBox1.Text);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.Close();
        }
    }
}
