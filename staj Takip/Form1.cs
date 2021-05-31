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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=staj.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        public static string ad;
        public static string soyad;
        public static string mail;
        public static string sınıf;
        public static int no; 
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT * FROM ogrenci where mail='" + textBox1.Text + "' AND şifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                ad = dr["ad"].ToString();
                soyad = dr["soyad"].ToString();
                mail = dr["mail"].ToString();
                sınıf = dr["sinif_no"].ToString();
                no = (int)dr["öğrenci_no"];
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mail ya da şifre yanlış");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT * FROM öğretmen where mail='" + textBox4.Text + "' AND şifre='" + textBox3.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                ad = dr["ad"].ToString();
                soyad = dr["soyad"].ToString();
                mail = dr["mail"].ToString();
                no = (int)dr["öğretmen_no"];
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mail ya da şifre yanlış");
            }

            con.Close();
        }
    }
    }

