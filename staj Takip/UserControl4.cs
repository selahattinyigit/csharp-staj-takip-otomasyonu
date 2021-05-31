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
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void griddoldur()
        {
            da = new OleDbDataAdapter("select * from ogrenci ", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables["ogrenci"];
            baglanti.Close();

        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "insert into ogrenci(öğrenci_no,ad,soyad,sinif_no,adres,mail,telefon,şifre) values ('" + textBox6.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + textBox4.Text + "','" + textBox8.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
            MessageBox.Show("KAYIT EKLENDİ");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
