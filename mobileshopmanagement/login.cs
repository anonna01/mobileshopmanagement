using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobileshopmanagement
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            uidtb.Text = "";
            passtb.Text ="";

        }

        private void uidtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (uidtb.Text == "" || passtb.Text == "") ;
            {
                MessageBox.Show("Enter the user Name & Password");
            }
            
            else if(uidtb.Text=="Admin" && passtb.Text=="Admin")
            {

            }
            else
            {
                MessageBox.Show("Incorrect User name or Password");
            }
        }
    }
}
