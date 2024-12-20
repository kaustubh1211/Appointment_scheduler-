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
    public partial class DoctorAdd : Form
    {
        public DoctorAdd()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f = new Form2();
            f.Show();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string doctorname;
            doctorname = DoctorName.Text.Trim();
            string connectionString = "server=LAPTOP-VKSFE2LA\\SQLEXPRESS; database= Appointment_Schedular; Trusted_Connection=true; ";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO DOCTOR(doctor_name) values(@doctorname)";


                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {



                    _cmd.Parameters.AddWithValue("@doctorname ", doctorname);


                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);


                    _con.Open();
                   int isWorking= _cmd.ExecuteNonQuery();


                    _con.Close();

                    if (isWorking > 0)
                    {
                        MessageBox.Show("Data Insertes Succesfully");
                                 DoctorName.Clear();                                                                                            
                    }
                    else
                    {

                        MessageBox.Show("Data is not Inserted");

                    }

                
                }

            }

        }

        private void DoctorAdd_Load(object sender, EventArgs e)
        {

        }

        private void DoctorName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
