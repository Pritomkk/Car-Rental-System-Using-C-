using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Car_Rental_Service
{
    public partial class car : Form
    {
        public car()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            conn.Open();
            string query = "select* from CarTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DataGridView2.DataSource = ds.Tables[0];


            conn.Close();


        }







        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)


        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RegNum.Text == "" ||
                Brand.Text == "" ||
                Model.Text == "" ||
                Price.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into CarTb1 values (' " + RegNum.Text + " ' , ' " + Brand.Text + "' , ' " + Model.Text + " ', '" + Available.SelectedItem.ToString() + "', '" + Price.Text + " ')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("car Successfully Added");
                    conn.Close();
                    populate();



                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void car_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            RegNum.Text = DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            Brand.Text = DataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            Model.Text = DataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            Available.Text = DataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            Price.Text = DataGridView2.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (RegNum.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from CarTb1 where RegNum ='" + RegNum.Text + " '; ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (RegNum.Text == "" ||
                Brand.Text == "" ||
                Model.Text == "" ||
                Price.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update CarTb1 set Model ='" + Model.Text + "',Brand= '" + Brand.Text + "', Available= '" + Available.SelectedItem.ToString() + "',Price= " + Price.Text + " Where RegNum='" + RegNum.Text + "'; ";
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform main = new Mainform();
            main.Show();
        }
    }
}
