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

namespace Appointment
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String phoneno= textBox4.Text.Trim();
            if(!System.Text.RegularExpressions.Regex.IsMatch(phoneno , @"^\d*$"))
            {
                MessageBox.Show("Values must be number");
                
                textBox4.Clear();
            }
            if (phoneno.Length > 9)
            {
                MessageBox.Show("Please enter valid 10 number");
                textBox4.Clear();

            }
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f =new Form2();
            f.Show();
             
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            String First_name;
            String Last_name;
            String Email;
            String phone;

            First_name = textBox1.Text.Trim();
            Last_name= textBox2.Text.Trim();
            Email = textBox3.Text.Trim();
            phone = textBox4.Text.Trim();


            if (First_name =="")
            {

                MessageBox.Show("First name is require");
                textBox1.Focus();
                return;
            }
            if (Last_name== "")
            {

                MessageBox.Show("Last name is require");
                textBox2.Focus();
                return;
            }
            if (Email == "")
            {

                MessageBox.Show("First name is require");
                textBox3.Focus();
                return;
            }
            if (phone == "")
            {

                MessageBox.Show("phone no  is require");
                textBox4.Focus();
                return;
            }

            // connection string

            string connectionString = "server=LAPTOP-VKSFE2LA\\SQLEXPRESS; database= Appointment_Schedular; Trusted_Connection=true; ";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO CLIENT_TABLE(FIRST_NAME , LAST_NAME , EMAIL, PHONE_NO) values(@First_name , @Last_name , @Email, @phone)";


                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {



                    _cmd.Parameters.AddWithValue("@First_name ",First_name );
                    _cmd.Parameters.AddWithValue("@Last_name ", Last_name);
                    _cmd.Parameters.AddWithValue("@Email ", Email);
                    _cmd.Parameters.AddWithValue("@phone ", phone);


                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);


                    _con.Open();
                    int isWorking = _cmd.ExecuteNonQuery();


                    _con.Close();

                    if (isWorking > 0)
                    {
                        MessageBox.Show("Data Insertes Succesfully" );
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        
                    }
                    else
                    {

                        MessageBox.Show("Data is not Inserted");

                    }


                }

            }
        }
    }
}
