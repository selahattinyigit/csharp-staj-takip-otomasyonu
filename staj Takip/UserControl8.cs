using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace staj_Takip
{
    public partial class UserControl8 : UserControl
    {
        public UserControl8()
        {
            InitializeComponent();
        }

        private void UserControl8_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.no.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=staj.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into staj(öğrenci_no,işletme_no,yetkili_kişi,sözleşme_tarihi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString("yyyy.MM.dd") + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("KAYIT EKLENDİ");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
