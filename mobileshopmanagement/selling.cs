using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobileshopmanagement
{
    public partial class selling : Form
    {
        public selling()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANU\Documents\MobilesoftDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select Mbrand,MModel,MPrice,from MobileTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobDgv.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void populateAccess()
        {
            Con.Open();
            String query = "Select Abrand,AModel,APrice,from AccessoriesTb1";
            SqlDataAdapter da =new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessDgv.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void selling_Load(object sender, EventArgs e)
        {
            populate();
            populateAccess();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application. Exit();
        }

        private void MobDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductTb.Text = MobDgv.SelectedRows[0].Cells[0].Value.ToString()+MobDgv.SelectedRows.Count.ToString();
            PriceTb.Text = MobDgv.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void AccessDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductTb.Text = AccessDgv.SelectedRows[0].Cells[0].Value.ToString() + AccessDgv.SelectedRows.Count.ToString();
            PriceTb.Text = AccessDgv.SelectedRows[0].Cells[2].Value.ToString();

        }
        int uprice;
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if(QuantityTb.Text =="")
            {
                MessageBox.Show("Enter The Quantity");

            }else
            {
                int total = Convert.ToInt32(QuantityTb.Text) * uprice;
                DataGridViewRow newRow = new DataGridView();
                newRow.CreateCells(BillDgv);
                newRow.Cells[0].Value = n + 1;

            }
        }
        //int uprice;
        private void button1_Click_1(object sender, EventArgs e)
        {
            int n = 0,Grdtotal=0;
            if(QuantityTb.Text=="" || PriceTb.Text=="")
            {
                MessageBox.Show("Enter the Quantity");

            }else
            {
                int total = Convert.ToInt32(QuantityTb.Text) * Convert.ToInt32(PriceTb.Text);
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(BillDgv);
                newrow.Cells[0].Value = n + 1;
                newrow.Cells[1].Value = ProductTb.Text;
                newrow.Cells[2].Value = PriceTb.Text;
                newrow.Cells[3].Value = QuantityTb.Text;
                newrow.Cells[4].Value = Total;
                BillDgv.Rows.Add(newrow);
                n++;
                Grdtotal = Grdtotal + total;
                Amtlbl.Text = "" + Grdtotal;
            }
        }

       
        
    }
}
