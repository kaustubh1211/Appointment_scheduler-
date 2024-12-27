using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
    

        private void button1_Click(object sender, EventArgs e)
        {


            string username;
            string password; 

            username = textBox1.Text;
            password = textBox2.Text;
     
     
            string query = "SELECT * FROM login WHERE username = @username AND login_password = @password";

            try
            {

            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("Password", password);

                DataTable dt = new DataTable();
                dt = (DataTable)datatable.data(cmd);

                if (dt.Rows.Count > 0)
                {

                    Form2 dash = new Form2();
                    dash.Show();
                    this.Hide();

                }
                else
                {

                    MessageBox.Show("Invalid credentials Please try again");
                }

            }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }

        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
