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
            Form2 f = new Form2();
            f.Show();
            this.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string doctorname;
            doctorname = DoctorName.Text.Trim();
            string connectionString = database.connectionString;
                string query = "INSERT INTO DOCTOR(doctor_name) values(@doctorname)";


            try { 
                using (SqlCommand _cmd = new SqlCommand(query))
                {
                    _cmd.Parameters.AddWithValue("@doctorname ", doctorname);


                int isWorking = (int)datatable.data(_cmd);

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
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}");
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
