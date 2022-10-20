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
    public partial class anushop : Form
    {
        public anushop()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 15;
        private void timer1_Tick(object sender, EventArgs e)
        {
           startpoint +=1;
            VprogressBar.Value = startpoint;
            LprogressBar.Value = startpoint;
            if (LprogressBar.Value ==100) 
            {
                int startpoint = 15;
                VprogressBar.Value = 0;
                LprogressBar.Value = 0;
                timer1.Stop();
                login log = new login();
                log.Show();
                this.Hide();

            }
        }

        private void anushop_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
