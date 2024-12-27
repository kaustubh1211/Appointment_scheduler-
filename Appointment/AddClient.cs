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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string email = textBox3.Text.Trim();

            // Check if the email is empty
         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form2 f =new Form2();
            f.Show();
            this.Close();
             
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

                MessageBox.Show("Email  is require");
                textBox3.Focus();
                return;
            }
          
                string email = textBox3.Text.Trim();

              
               

                // Validate the email format using regex
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    textBox3.Clear();
                    textBox3.Focus();
                }
           

            if (phone == "")
            {

                MessageBox.Show("phone no  is require");
                textBox4.Focus();
                return;
            }
            String phoneno = textBox4.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneno, @"^\d*$"))
            {
                MessageBox.Show("Values must be number");

                textBox4.Clear();
                textBox4.Focus();
                return;
            }
            if (phoneno.Length != 10)
            {
                MessageBox.Show("Please enter valid 10 number");
                textBox4.Clear();
                textBox4.Focus();
                return;

            }
    

        

                string query = "INSERT INTO CLIENT_TABLE(FIRST_NAME , LAST_NAME , EMAIL, PHONE_NO) values(@First_name , @Last_name , @Email, @phone_no)";



                    using(SqlCommand _cmd =new SqlCommand(query))
                     {

                       _cmd.Parameters.AddWithValue("@FIRST_NAME", First_name);
                        _cmd.Parameters.AddWithValue("@LAST_NAME", Last_name);
                        _cmd.Parameters.AddWithValue("@EMAIL", Email);
                         _cmd.Parameters.AddWithValue("@PHONE_NO", phoneno);
                        int rowsAffected = (int)datatable.data(_cmd);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data insertes succesfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Data not inserted");
                }

                        }

        


            
        }

     



    }
}
