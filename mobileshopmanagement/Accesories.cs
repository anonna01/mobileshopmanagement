using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace mobileshopmanagement
{
    public partial class Accesories : Form
    {
        public Accesories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANU\Documents\MobilesoftDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select*from AccessoriesTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds new DataSet();
            da.Fill(ds);
            AccessDgv.DataSource = ds.tables[0];
            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (AIdTb.Text == "" || ABrandTb.Text == "" || AModelTb.Text == "" || APriceTb.Text == "" || AStockTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string sql = "insert into AccessoriesTb1 values(" + AIdTb.Text + "," + ABrandTb.Text + "," + AModelTb.Text + "," + APriceTb.Text + "," + AStockTb.Text + ",)";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories added succesfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);


                }

            }
        }

        private void Accesories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AIdTb.Text = "";
            ABrandTb.Text = "";
            AModelTb.Text = "";
            APriceTb.Text = "";
            AStockTb.Text = "";
        }

        private void AccessDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AIdTb.Text = AccessDgv.SelectedRows[0].Cells[0].Value.ToString();
            ABrandTb.Text = AccessDgv.SelectedRows[0].Cells[1].Value.ToString();
            AModelTb.Text = AccessDgv.SelectedRows[0].Cells[2].Value.ToString();
            APriceTb.Text = AccessDgv.SelectedRows[0].Cells[3].Value.ToString();
            AStockTb.Text = AccessDgv.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AIdTb.Text == "")
            {
                MessageBox.Show("Enter the Accesories to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from AccessoriesTb1 Where AId= " + AIdTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AIdTb.Text == "" || ABrandTb.Text == "" || AModelTb.Text == "" || APriceTb.Text == "" || AStockTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string sql = " Update AccessoriesTb1 set ABrand= '" + ABrandTb.Text + "',AModel='" + AModelTb.Text + "',APrice='" + APriceTb.Text + "',Mstock='" + AStockTb.Text + ",where AId=" + AIdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Updated succesfully");
                    populate();
                    Con.Close();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);


                }

            }
        }
    }
}
