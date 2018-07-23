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
    public partial class Bill : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select CNAME from BOOKING_O", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CNAME"].ToString());
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from BOOKING_O where CNAME='" + comboBox1.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["PNAME"].ToString();
                textBox3.Text = dr["RNAME"].ToString();
                textBox4.Text = dr["GNAME"].ToString();
                textBox8.Text = dr["TOTALPRICE"].ToString();
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.textBox5.Text += "PISTOL NAME :" + textBox2.Text + Environment.NewLine;
            this.textBox5.Text += "RIFEL NAME :" + textBox3.Text + Environment.NewLine;
            this.textBox5.Text += "GRNADE NAME :" + textBox4.Text + Environment.NewLine;
            this.textBox5.Text += "TOTAL PRICE :" + textBox8.Text + Environment.NewLine;
          
        }
    }
}
