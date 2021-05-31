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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand cmd = new OleDbCommand();
        public void griddoldur()
        {

            da = new OleDbDataAdapter("select * from öğretmen where mail='" + Form1.mail.ToString() + "'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "öğretmen");
            dataGridView1.DataSource = ds.Tables["öğretmen"];
            baglanti.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Update öğretmen Set ad=@ad,soyad=@soyad,telefon=@tel,şifre=@sifre Where mail=@mail";
            cmd = new OleDbCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
 
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
           
            textBox5.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            griddoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
