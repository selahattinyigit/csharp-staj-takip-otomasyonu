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
    public partial class UserControl7 : UserControl
    {
        public UserControl7()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand cmd = new OleDbCommand();
        public void griddoldur()
        {

            da = new OleDbDataAdapter("select * from işletme ", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "işletme");
            dataGridView1.DataSource = ds.Tables["işletme"];
            baglanti.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl7_Load(object sender, EventArgs e)
        {
            griddoldur();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into işletme (ad,adres,ilçe_no,Telefon,kontenjan) values (@ad,@adres,@ilçe_no,@tel,@kontejan)";
           cmd  = new OleDbCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@adres", textBox4.Text);
            cmd.Parameters.AddWithValue("@ilçe_no", textBox2.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@kontejan", textBox5.Text);
            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
            
            griddoldur();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("Kayıt Eklendi");
        }
    }
}
