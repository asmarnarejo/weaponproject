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
    public partial class approvel : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public approvel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
          cmd = new SqlCommand("Update customer_d set status='open' where cid ='" + comboBox1.Text + "'", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("vendor has been approved");
            conn.Close();
            WEAPON_DETAILS WP = new WEAPON_DETAILS();
            WP.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DISAPPROVE da = new DISAPPROVE();
            da.Show();
            this.Hide();
        }

        private void approvel_Load(object sender, EventArgs e)
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
    }
}
