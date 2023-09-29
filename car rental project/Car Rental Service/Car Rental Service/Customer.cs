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
using System.Diagnostics;
using System.Reflection;

namespace Car_Rental_Service
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }



        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            conn.Open();
            string query = "select* from CustomerTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DataGridView3.DataSource = ds.Tables[0];


            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CustId.Text == "" ||
                CustName.Text == "" ||
                CustAdd.Text == "" ||
                Phone.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into CustomerTb1 values (' " + CustId.Text + " ' , ' " + CustName.Text + "' , ' " + CustAdd.Text + " ',  '" + Phone.Text + " ')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                    conn.Close();
                    populate();



                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform main = new Mainform();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CustId.Text == "" ||
                CustName.Text == "" ||
                CustAdd.Text == "" ||
                Phone.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update CustomerTb1 set CustAdd='" + CustAdd.Text + "',CustName= '" + CustName.Text + "', Phone= " + Phone.Text + " Where CustId='" + CustId.Text + "'; ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully ");
                    conn.Close();
                    populate();



                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustId.Text = DataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            CustName.Text = DataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            CustAdd.Text = DataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            Phone.Text = DataGridView3.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CustId.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from CustomerTb1 where CustId ='" + CustId.Text + " '; ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfully");
                    conn.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }



            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

}



