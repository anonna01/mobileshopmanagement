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
    public partial class MOBILE : UserControl
    {
        public MOBILE()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ANU\Documents\MobilesoftDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mobidtb.Text = Mobdgv.SelectedRows[0].Cells[0].Value.ToString();
            Brandtb.Text = Mobdgv.SelectedRows[0].Cells[1].Value.ToString();
            Modeltb.Text = Mobdgv.SelectedRows[0].Cells[2].Value.ToString();
            pricetb.Text = Mobdgv.SelectedRows[0].Cells[3].Value.ToString();
            Ramcb.SelectedItem = Mobdgv.SelectedRows[0].Cells[4].Value.ToString();
            stocktb.Text = Mobdgv.SelectedRows[0].Cells[5].Value.ToString();
            Romcb.SelectedItem = Mobdgv.SelectedRows[0].Cells[6].Value.ToString();
        }
        private void populate()
        {
            Con.Open();
            string query = "select*from mobiletb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds new Dataset();
            da.Fill(ds);
            Mobdgv.Datasource = ds.tables[0];
            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "" || Brandtb.Text == "" || Modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string sql = "insert into mobilletb1 values(" + Mobidtb.Text + "," + Brandtb.Text + "," + Modeltb.Text + "," + pricetb.Text + "," + stocktb.Text + "," + Ramcb.SelectedItem.ToString() + "," + Romcb.SelectedItem.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile added succesfully");
                    Con.Close();
                    populate();

                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);


                }

            }
        }

        private void MOBILE_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mobidtb.Text = "";
            Brandtb.Text = "";
            Modeltb.Text = "";
            pricetb.Text = "";
            stocktb.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "")
            {
                MessageBox.Show("Enter the mobile to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete ffrom Mobiletb1 Where Mobid= " + Mobidtb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)

            }



                private void button2_Click(object sender, EventArgs e)
                {
                    if (Mobidtb.Text == "" || Brandtb.Text == "" || Modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "")
                    {
                        MessageBox.Show("Missing Information");

                    }
                    else
                    {
                        try
                        {
                            Con.Open();
                            string sql = " Update MobileTb1 set Mbrand= '" + Brandtb.Text + "',Mmodel='" + Modeltb.Text + "',Mprice='" + pricetb.Text + "',MRam='" + Ramcb.SelectedItem.ToString() + "',Mstock='" + stocktb.Text + "',MRom='" + Romcb.SelectedItem.ToString() + "'where MobId=" + Mobidtb.Text + ";";
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


    }
}

