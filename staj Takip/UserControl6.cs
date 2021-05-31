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
    public partial class UserControl6 : UserControl
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=staj.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        public UserControl6()
        {
            InitializeComponent();
        }
        public void griddoldur()
        {
            da = new OleDbDataAdapter("select * from bölüm ", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "bölüm");
            dataGridView1.DataSource = ds.Tables["bölüm"];
            baglanti.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl6_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            griddoldur();
        }
    }
}
