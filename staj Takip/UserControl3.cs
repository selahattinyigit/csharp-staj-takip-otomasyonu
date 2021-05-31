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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        public void griddoldur()
        {

            da = new OleDbDataAdapter("select * from sinif where sinif_no='" + Form1.sınıf.ToString() + "'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "sinif");
            dataGridView1.DataSource = ds.Tables["sinif"];
            baglanti.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            griddoldur();
        }
    }
}
