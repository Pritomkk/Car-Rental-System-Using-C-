using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Service
{
    public partial class Totalcar_customer_Employe : Form
    {
        public Totalcar_customer_Employe()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");

        private void Totalcar_customer_Employe_Load(object sender, EventArgs e)
        {
            String querycar = "select Count(*) from CarTb1";
            SqlDataAdapter sda = new SqlDataAdapter(querycar,conn);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            carlb1.Text = dt.Rows[0][0].ToString();

            String querycust = "select Count(*) from CustomerTb1";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Custlb.Text = dt1.Rows[0][0].ToString();

            String queryemploye = "select Count(*)from AdminTb1";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryemploye, conn);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Emp.Text = dt2.Rows[0][0].ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainform mainform = new Mainform();
            mainform.Show();
        }

        private void carlb1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
