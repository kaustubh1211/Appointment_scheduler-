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


            // connection string
            string connectionString = "server=LAPTOP-VKSFE2LA\\SQLEXPRESS; database= Appointment_Schedular; Trusted_Connection=true; ";


            using (SqlConnection _con = new SqlConnection(connectionString)) {

                string query = "SELECT * FROM login WHERE username = @username AND login_password = @password";
                using (SqlCommand _cmd = new SqlCommand(query, _con))
            {
                    _cmd.Parameters.AddWithValue("@username", username);
                    _cmd.Parameters.AddWithValue("@password", password);


                    DataTable dt = new DataTable();

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    
                    _con.Open();
                    _dap.Fill(dt);
                    _con.Close();

                    // check the rows for condition 
                    // if no matching from database the dt.rows.Count is 0
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



        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
