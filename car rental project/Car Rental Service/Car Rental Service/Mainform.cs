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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResisterAdmin admin  = new ResisterAdmin();
            admin.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            car car = new car();
            car.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Customer cus = new Customer();
            cus.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental Rent = new Rental();
            Rent.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
           // Return car = new car();
           // car.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LOGIN LOG = new LOGIN();
            LOG.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            Totalcar_customer_Employe Total = new Totalcar_customer_Employe();
            Total.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Totalcar_customer_Employe T = new Totalcar_customer_Employe();
            T.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Totalcar_customer_Employe To = new Totalcar_customer_Employe();
            To.Show();
        }
    }
}
