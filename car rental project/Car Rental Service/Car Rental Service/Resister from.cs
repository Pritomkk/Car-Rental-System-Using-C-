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

namespace Car_Rental_Service
{
    public partial class Resister_from : Form
    {
        public Resister_from()
        {
            InitializeComponent();
        }

    


        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Pritom Chandra Dey\Documents\CarrentalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
         

            if (textBoxfName.Text =="" || 
                textBoxLName.Text == "" ||
                UserName.Text == "" ||
                Email.Text == "" ||
                Password.Text == "" 
                )
            {
                MessageBox.Show("Fill the Box Properly");
            }
            else
            {

                try
                {
                    conn.Open();
                    string query = "insert into AdminTb1 values (' " + textBoxfName.Text + " ' , ' " + textBoxLName.Text + "' , ' " + UserName.Text + " ', '" + Email.Text + "', '" + Password.Text + " ','" + ConfirmPass.Text + " ')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex .Message);   

                }
                finally
                {
                    MessageBox.Show("Registration Sucessfull");
                }


                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (Password.Text == ConfirmPass.Text)
            {
                labelRight1.Visible = true;
                labelWrong1.Visible = false;
            }
            else
            {
                labelRight1.Visible = false;
                labelWrong1.Visible = true;
            }
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            string email = Email.Text;
            if (email.Contains("@") && email.Contains("."))
            {
                labelRight2.Visible = true;
                Labelworng2.Visible = false;
            }
            else
            {
                labelRight2.Visible = false;
                Labelworng2.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
