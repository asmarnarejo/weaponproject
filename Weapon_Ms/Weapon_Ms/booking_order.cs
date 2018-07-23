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
    public partial class booking_order : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public booking_order()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.groupBox2.Visible = true;
            }
            this.groupBox3.Visible = false;
            this.groupBox4.Visible = false;
        }

        private void booking_order_Load(object sender, EventArgs e)
        {

            conn.Open();
            cmd = new SqlCommand("select cid from customer_d", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["cid"].ToString());
                comboBox8.Items.Add(dr["cid"].ToString());
                comboBox5.Items.Add(dr["cid"].ToString());


            }
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("select NAME from PISTOL", conn);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox3.Items.Add(dr1["NAME"].ToString());
               
               
            }
                conn.Close();
            
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;
                this.groupBox4.Visible = false;
                
            conn.Open();
                cmd = new SqlCommand("select NAME from RIFLE", conn);
                SqlDataReader dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    comboBox4.Items.Add(dr2["NAME"].ToString());
                   
                }
                conn.Close();

                conn.Open();
                cmd = new SqlCommand("select NAME from GRENADE", conn);
                SqlDataReader dr3 = cmd.ExecuteReader();
                while (dr3.Read())
                {
                    comboBox7.Items.Add(dr3["NAME"].ToString());
                    
                }
                conn.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.groupBox3.Visible = true;
            }
            this.groupBox2.Visible = false;
            this.groupBox4.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.groupBox4.Visible = true;
            }
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from customer_d where cid='" + comboBox2.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["cname"].ToString();
                

            }
            conn.Close();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from customer_d where cid='" + comboBox8.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox6.Text = dr["cname"].ToString();
                
            }
            conn.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from customer_d where cid='" + comboBox5.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox4.Text = dr["cname"].ToString();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t;
            int u;
            int v;
            int s;
            t = Convert.ToInt32(textBox15.Text);
            u = Convert.ToInt32(textBox16.Text);
            v = Convert.ToInt32(textBox17.Text);
            s = t + u + v;
            textBox8.Text = s.ToString();

            conn.Open();
            cmd = new SqlCommand("insert into BOOKING_O(CNAME,PNAME,PQUANTITY,RNAME,RQUANTITY,GNAME,GQUANTITY,PPRICE,RPRICE,GPRICE,TOTALPRICE) VALUES(@CNAME,@PNAME,@PQUANTITY,@RNAME,@RQUANTITY,@GNAME,@GQUANTITY,@PPRICE,@RPRICE,@GPRICE,@TOTALPRICE)", conn);
            cmd.Parameters.AddWithValue("CNAME", this.textBox2.Text);
            cmd.Parameters.AddWithValue("PNAME", this.comboBox3.Text);
            cmd.Parameters.AddWithValue("PQUANTITY", this.textBox3.Text);
            cmd.Parameters.AddWithValue("RNAME", this.comboBox4.Text);
            cmd.Parameters.AddWithValue("RQUANTITY", this.textBox1.Text);
            cmd.Parameters.AddWithValue("GNAME", this.comboBox7.Text);
            cmd.Parameters.AddWithValue("GQUANTITY", this.textBox5.Text);
            cmd.Parameters.AddWithValue("PPRICE", this.textBox9.Text);
            cmd.Parameters.AddWithValue("RPRICE", this.textBox11.Text);
            cmd.Parameters.AddWithValue("GPRICE", this.textBox10.Text);
            cmd.Parameters.AddWithValue("TOTALPRICE", this.textBox8.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("ur record has ben inserted");
            Bill bb = new Bill();
            bb.Show();
            this.Hide();
            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from PISTOL where NAME='" + comboBox3.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox9.Text = dr["price"].ToString();
            }
            conn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int a;
            int b;
            int c;
            a = Convert.ToInt32(textBox3.Text);
            b = Convert.ToInt32(textBox9.Text);
            c = a * b;
            textBox15.Text = c.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int d;
            int g;
            int f;
            d = Convert.ToInt32(textBox5.Text);
            g = Convert.ToInt32(textBox10.Text);
            f = d * g;
            textBox16.Text = f.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int h;
            int i;
            int j;
            h = Convert.ToInt32(textBox1.Text);
            i = Convert.ToInt32(textBox11.Text);
            j = h * i;
            textBox17.Text = j.ToString();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from GRENADE where NAME='" + comboBox7.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox10.Text = dr["price"].ToString();
            }
            conn.Close();
        }
        
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from RIFLE where NAME='" + comboBox4.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox11.Text = dr["price"].ToString();
            }
            conn.Close();
        }
    }
}
