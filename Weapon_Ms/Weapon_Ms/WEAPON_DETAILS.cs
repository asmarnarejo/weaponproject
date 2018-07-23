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
    public partial class WEAPON_DETAILS : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=ASMAR\SQLEXPRESS;Initial Catalog=weapon;Integrated Security=True");
        public WEAPON_DETAILS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            booking_order bo = new booking_order();
            bo.Show();
            this.Hide();
        }

        private void WEAPON_DETAILS_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select NAME from PISTOL", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["NAME"].ToString());
                
            }
            conn.Close();
            
                conn.Open();
                cmd = new SqlCommand("select NAME from RIFLE", conn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    comboBox2.Items.Add(dr1["NAME"].ToString());
                    
                }
                conn.Close();
                
                    conn.Open();
                    cmd = new SqlCommand("select NAME from GRENADE", conn);
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    while (dr2.Read())
                    {
                        comboBox3.Items.Add(dr2["NAME"].ToString());
                       
                    }
                    conn.Close();
                }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from PISTOL where NAME='" + comboBox1.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["MODEL"].ToString();
                textBox2.Text = dr["MANUFACTURER"].ToString();
                textBox3.Text = dr["MAGAZINE"].ToString();
                textBox4.Text = dr["RANGE"].ToString();
                textBox5.Text = dr["PRICE"].ToString();
               

            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from RIFLE where NAME='" + comboBox2.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox10.Text = dr["MODEL"].ToString();
                textBox9.Text = dr["MANUFACTURER"].ToString();
                textBox8.Text = dr["MAGAZINE"].ToString();
                textBox7.Text = dr["RANGE"].ToString();
                textBox6.Text = dr["PRICE"].ToString();


            }
            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from GRENADE where NAME='" + comboBox3.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox15.Text = dr["MODEL"].ToString();
                textBox14.Text = dr["MANUFACTURE"].ToString();
                textBox13.Text = dr["KILLRADIUS"].ToString();
                textBox12.Text = dr["PRICE"].ToString();


            }
            conn.Close();
        }
            }
        }
   