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
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f = new Form2();
            f.Show();
        }


        // add doctor into combobox2
        private void AddDoctor(String Doctor_name)
        {
            comboBox2.Items.Add(Doctor_name);

        }
        //add client first name into combobox1
        private void AddClient(String Client_name)
        {
            comboBox1.Items.Add(Client_name);
            
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // connection string
            

                    // check the rows for condition 
                    // if no matching from database the dt.rows.Count is 0

                }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            string connectionString = "server=LAPTOP-VKSFE2LA\\SQLEXPRESS; database= Appointment_Schedular; Trusted_Connection=true; ";


            using (SqlConnection _con = new SqlConnection(connectionString))
            {

                string query = " SELECT DOCTOR_NAME FROM DOCTOR";
                
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {



                    //DataTable dt = new DataTable();
                    //SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _con.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();

                    // _dap.Fill(dt);

                    while (reader.Read())
                    {
                        AddDoctor(reader["doctor_name"].ToString());
                    }

                    reader.Close();

                }
                string quey2 = "SELECT FIRST_NAME FROM CLIENT_TABLE";
                using (SqlCommand _cmd =new SqlCommand(quey2, _con))
                {

                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AddClient(reader["FIRST_NAME"].ToString());
                    }
                    _con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
