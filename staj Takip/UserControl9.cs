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
    public partial class UserControl9 : UserControl
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand cmd = new OleDbCommand();
        public UserControl9()
        {
            InitializeComponent();
        }
        public void griddoldur()
        {
            da = new OleDbDataAdapter("select * from staj ", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "staj");
            dataGridView1.DataSource = ds.Tables["staj"];
            baglanti.Close();

        }
        private void UserControl9_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            label3.Text = Form1.no.ToString();
            griddoldur();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Update staj SET onay_öğ_id=@onay Where öğrenci_no=@no";
            cmd = new OleDbCommand(sorgu,baglanti);
            
        
            cmd.Parameters.AddWithValue("@onay", Form1.no.ToString());
            cmd.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[1].Value.ToString());

            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
            MessageBox.Show("Staj Yeri Onaylandı...");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Update staj SET kord_öğ_id=@onay Where öğrenci_no=@no";
            cmd = new OleDbCommand(sorgu, baglanti);


            cmd.Parameters.AddWithValue("@onay", Form1.no.ToString());
            cmd.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[1].Value.ToString());

            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
            MessageBox.Show("Kordinator Öğretmeni Oldunuz..");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Update staj SET tamamlandı=@onay Where öğrenci_no=@no";
            cmd = new OleDbCommand(sorgu, baglanti);

            string a = "Evet";
            cmd.Parameters.AddWithValue("@onay",a );
            cmd.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[1].Value.ToString());

            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
            MessageBox.Show("Stajını Tamamladı..");
        }
    }
}
