using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Service
{
    public partial class Opening : Form
    {
        public Opening()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MyProgress_ValueChanged(object sender, EventArgs e)
        {
            
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        int startpoint = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint+= 1;
            Myprogess.Value = startpoint;
            Percentage.Text = " " + startpoint;
            if(Myprogess.Value==100)
            { 
                Myprogess.Value = 0;
                timer1.Stop();
                LOGIN log =new LOGIN();
                log.Show();
                this.Hide();
            }
            



        }

        private void Percentage_Click(object sender, EventArgs e)
        {

        }
    }
}
