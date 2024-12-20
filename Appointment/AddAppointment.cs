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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Appointment.Model;

namespace Appointment
{
    public partial class AddAppointment : Form
    {
        List<ClientAdd> ca = new List<ClientAdd>();

        List<AddDoctor> da= new List<AddDoctor>();

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

                string query = " SELECT * FROM CLIENT_TABLE";
                
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {



                    DataTable dt = new DataTable();
                   SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _con.Open();
                 

                    _dap.Fill(dt);

              
                    foreach(DataRow row in dt.Rows)
                    {
                        ClientAdd obj = new ClientAdd();
                        obj.client_name = row["first_name"].ToString();
                        obj.client_id = Convert.ToInt32(row["client_id"]);

                        ca.Add(obj);
                        comboBox1.Items.Add(row["first_name"].ToString());
                    }

                    _con.Close();
                }



                string quey2 = "SELECT * FROM DOCTOR";
                using (SqlCommand _cmd =new SqlCommand(quey2, _con))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _con.Open();


                    _dap.Fill(dt);

                    foreach (DataRow row in dt.Rows )
                    {
                        AddDoctor obj = new AddDoctor();
                        obj.doctor_name = row["doctor_name"].ToString();
                        obj.doctor_id = Convert.ToInt32(row["doctor_id"]);

                        da.Add(obj);
                        comboBox2.Items.Add(row["doctor_name"].ToString());
                    }
                    
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int client_id;
            int doctor_id;
            DateTime date;
            DateTime time;
            client_id = comboBox2.SelectedIndex;
            doctor_id   = comboBox1.SelectedIndex;
            date = dateTimePicker1.Value;
            time = dateTimePicker2.Value;


            string connectionString = "server=LAPTOP-VKSFE2LA\\SQLEXPRESS; database= Appointment_Schedular; Trusted_Connection=true; ";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO APPOINTMENT_TABLE(CLIENT_ID , DOCTOR_ID , APPOINTMENT_DATE, APPOINTMENT_TIME) values(@client_id , @doctor_id , @date, @time)";


                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {



                    _cmd.Parameters.AddWithValue("@client_id ", client_id);
                    _cmd.Parameters.AddWithValue("@doctor_id ", doctor_id);
                    _cmd.Parameters.AddWithValue("@date ", date);
                    _cmd.Parameters.AddWithValue("@time ", time);


                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);


                    _con.Open();
                    int isWorking = _cmd.ExecuteNonQuery();


                    _con.Close();

                    if (isWorking > 0)
                    {
                        MessageBox.Show("Data Insertes Succesfully");
               

                    }
                    else
                    {

                        MessageBox.Show("Data is not Inserted");

                    }


                }

            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
