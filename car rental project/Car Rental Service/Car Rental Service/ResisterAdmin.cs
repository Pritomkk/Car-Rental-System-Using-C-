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

namespace Car_Rental_Service
{
    public partial class ResisterAdmin : Form
    {
        public ResisterAdmin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            conn.Open();
            string query = "select FirstName ,LastName, UserName ,Email from AdminTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ViewAdmin.DataSource = ds.Tables[0];


            conn.Close();


        }


        private void ResisterAdmin_Load(object sender, EventArgs e)
        {
            populate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform main =new Mainform();
            main.Show();
        }

        private void ViewAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
