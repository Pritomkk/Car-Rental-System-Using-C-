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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Car_Rental_Service
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string login = ("SELECT * FROM AdminTb1 WHERE Email =  '" + Email.Text + "' and Password = '" + Pass.Text + "' ");
                cmd = new SqlCommand(login, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {

                    conn.Close();


                    Mainform mainform = new Mainform();
                    mainform.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials, please try Again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Email.Text = "";
                    Pass.Text = "";
                    Email.Focus();
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                }

            }

            catch (Exception Myex)
            {
                MessageBox.Show(Myex.Message);
            }






        }







        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Resister_from aa = new Resister_from();
            aa.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

 

