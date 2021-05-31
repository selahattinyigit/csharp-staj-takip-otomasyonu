using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staj_Takip
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl2 usr = new UserControl2();
            panel1.Controls.Add(usr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl4 usr = new UserControl4();
            panel1.Controls.Add(usr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl5 usr = new UserControl5();
            panel1.Controls.Add(usr);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl6 usr = new UserControl6();
            panel1.Controls.Add(usr);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Ad :" + Form1.ad.ToString();
            label2.Text = "Soyad :" + Form1.soyad.ToString();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl9 usr = new UserControl9();
            panel1.Controls.Add(usr);
        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}
