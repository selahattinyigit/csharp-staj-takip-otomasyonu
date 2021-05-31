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
    public partial class UserControl5 : UserControl
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        public UserControl5()
        {
            InitializeComponent();
        }
        public void griddoldur()
        {
            da = new OleDbDataAdapter("select * from sinif ", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "sinif");
            dataGridView1.DataSource = ds.Tables["sinif"];
            baglanti.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            griddoldur();
        }
    }
}
