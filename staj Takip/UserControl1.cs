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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand cmd = new OleDbCommand();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
        }
        public void griddoldur()
        {
            
            da = new OleDbDataAdapter("select * from ogrenci where mail='" + Form1.mail.ToString() + "'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables["ogrenci"];
            baglanti.Close();

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            griddoldur();
            dataGridView1.Columns[0].HeaderText = "Numara";

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Update ogrenci Set ad=@ad,soyad=@soyad,adres=@adres,telefon=@tel,şifre=@sifre Where mail=@mail";
            cmd = new OleDbCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@adres", textBox4.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox5.Text);
            cmd.Parameters.AddWithValue("@mail", Form1.mail.ToString());
            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgileriniz Güncellendi");
            griddoldur();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
