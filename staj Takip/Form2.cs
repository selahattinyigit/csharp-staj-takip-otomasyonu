using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace staj_Takip
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=staj.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl1 usr = new UserControl1();
            panel1.Controls.Add(usr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl3 usr = new UserControl3();
            panel1.Controls.Add(usr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl6 usr = new UserControl6();
            panel1.Controls.Add(usr);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Ad :" + Form1.ad.ToString();
            label3.Text = Form1.no.ToString();
            label2.Text = "Soyad :" + Form1.soyad.ToString();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT * FROM staj where öğrenci_no='" +label3.Text +"'" ;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                MessageBox.Show("staj bilgilerinizi girdiniz...");
            }
            else
            {
                panel1.Controls.Clear();
                UserControl8 usr = new UserControl8();
                panel1.Controls.Add(usr);
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl7 usr = new UserControl7();
            panel1.Controls.Add(usr);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
