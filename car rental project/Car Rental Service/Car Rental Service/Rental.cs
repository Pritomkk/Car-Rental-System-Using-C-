using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Service
{
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void fillcarreg()
        {
            conn.Open();
            string query = "select RegNum from CarTb1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(reader);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;

            conn.Close();

        }
        private void fetchCustId()
        {
            conn.Open();
            string query = "select CustId from CustomerTb1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(string));
            dt.Load(reader);
            Custcb.ValueMember = "CustId";
            Custcb.DataSource = dt;

            conn.Close();

        }
        private void populate2()
        {
            conn.Open();
            string query = "select* from CarTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DataGridView3.DataSource = ds.Tables[0];


            conn.Close();


        }









        private void populate()
        {
            conn.Open();
            string query = "select * from RentalTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DataGridView4.DataSource = ds.Tables[0];


            conn.Close();


        }

        private void updateRent()
        {
            conn.Open();
            string query = "update CarTb1 set  Available= '" +"No" + "' Where RegNum='" +CarRegCb.SelectedValue.ToString()+ "'; " ;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
           
            conn.Close();
        }

        private void updateDelete()
        {
            conn.Open();
            string query = "update CarTb1 set  Available= '" + "Yes" + "' Where RegNum='" + CarRegCb.SelectedValue.ToString() + "'; ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            fillcarreg();
            fetchCustId();
            populate();
            populate2();

        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void Custcb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (RentId.Text == "" ||

                RentFee.Text == ""
                )
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into RentalTb1 values (" +RentId.Text + " , ' " + CarRegCb.SelectedValue.ToString() + "' , '" + Custcb.SelectedValue.ToString() + "' , ' " + RentDate.Text + " ', '" + ReturnDate.Text + " ', " + RentFee.Text+ ")";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent Successfully");
                    conn.Close();
                    populate();
                    updateRent();



                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            RentId.Text = DataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            
            
            //CarRegCb.SelectedValue = DataGridView4.SelectedRows[0].Cells[1].Value.ToString();
           // Custcb.SelectedValue = DataGridView4.SelectedRows[0].Cells[2].Value.ToString();
            RentFee.Text = DataGridView4.SelectedRows[0].Cells[5].Value.ToString();
           
        }

        private void RentFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform main = new Mainform();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RentId.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from RentalTb1 where RentId =" + RentId.Text + " ; ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfully");
                    conn.Close();
                    populate();
                    updateDelete();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
