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
    public partial class ViewAppointments : Form
    {
        public ViewAppointments()
        {
            InitializeComponent();
        }

        private void ViewAppointments_Load(object sender, EventArgs e)
        {


            string connectionString = "server=LAPTOP-VKSFE2LA\\SQLEXPRESS; database= Appointment_Schedular; Trusted_Connection=true; ";


            using (SqlConnection _con = new SqlConnection(connectionString))
            {

                string query = "SELECT  at.appointment_id, ct.first_name AS client_name,  d.doctor_name,  at.appointment_date,  at.appointment_time,  at.appointment_status FROM  appointment_table at JOIN  client_table ct ON at.client_id = ct.client_id JOIN   doctor d ON at.doctor_id = d.doctor_id";
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                


                    DataTable dt = new DataTable();

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);


                    _con.Open();
                    _dap.Fill(dt);
                    _con.Close();

                    // check the rows for condition 
                    // if no matching from database the dt.rows.Count is 0

                    
                    dataGridView1.DataSource = dt;
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }
    }
}
