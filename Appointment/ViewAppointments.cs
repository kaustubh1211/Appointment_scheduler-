using Appointment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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



                string query = "SELECT at.appointment_id, ct.first_name AS client_name,  d.doctor_name,  at.appointment_date,  at.appointment_time,  at.appointment_status FROM  appointment_table at JOIN  client_table ct ON at.client_id = ct.client_id JOIN   doctor d ON at.doctor_id = d.doctor_id";
              
            using (SqlCommand _cmd = new SqlCommand(query))
                {
                


                    DataTable dt = new DataTable();

                dt = (DataTable) datatable.data(_cmd); 


              
                    dataGridView1.DataSource = dt;


                    // setup the status section 
               
                    DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
                    statusColumn.Name = "Status";
                    statusColumn.HeaderText="Appointmen Schedular ";
                    statusColumn.Items.AddRange("Pending", "Completed", "Cancelled");
                    statusColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    dataGridView1.Columns.Add(statusColumn);

                    //update button section 
                    DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
                    updateButton.Name = "UpdateButton";
                    updateButton.HeaderText = "Update";
                    updateButton.Text = "Update";
                    updateButton.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(updateButton);


                    dataGridView1.AllowUserToAddRows = false;
                
                dataGridView1.BackgroundColor = Color.LightGray;
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;
                // color row

                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;



            }
            dataGridView1.CellClick += DataGridView1_CellClick;

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    
            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index && e.RowIndex >= 0)
            {
                // gettting id and satatus from selected
                int appointmentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["appointment_id"].Value);
                string updatedStatus = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                if (string.IsNullOrEmpty(updatedStatus))
                {
                    MessageBox.Show("select The status to update");
                    return;
                }

                // update status

                    string updateQuery = "UPDATE appointment_table SET appointment_status = @status WHERE appointment_id = @id";
                   
                    using (SqlCommand _cmd = new SqlCommand(updateQuery))
                    {
                        _cmd.Parameters.AddWithValue("@status", updatedStatus);
                        _cmd.Parameters.AddWithValue("@id", appointmentId);

                    int isWorking = (int)datatable.data(_cmd);

                    if (isWorking > 0)
                        {
                            MessageBox.Show("Appointment status updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update appointment status");
                        }
                    }




                    // update data after update  
                
                        string query = "SELECT at.appointment_id, ct.first_name AS client_name,  d.doctor_name,  at.appointment_date,  at.appointment_time,  at.appointment_status FROM  appointment_table at JOIN  client_table ct ON at.client_id = ct.client_id JOIN   doctor d ON at.doctor_id = d.doctor_id";
                        using (SqlCommand _cmd = new SqlCommand(query))
                        {



                            DataTable dt = new DataTable();
                             dt=(DataTable)datatable.data(_cmd);

                            dataGridView1.DataSource = dt;

                        }

                    
                
            }
        }


        //back button
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            object satusValue  ;
            satusValue =comboBox1.SelectedItem ;

                string query = "SELECT  at.appointment_id, ct.first_name AS client_name,  d.doctor_name,  at.appointment_date,  at.appointment_time,  at.appointment_status FROM  appointment_table at JOIN  client_table ct ON at.client_id = ct.client_id JOIN   doctor d ON at.doctor_id = d.doctor_id where at.appointment_status=@status";
                using (SqlCommand _cmd = new SqlCommand(query))
                {
                    _cmd.Parameters.AddWithValue("@status", satusValue);

                    DataTable dt = new DataTable();
                dt = (DataTable)datatable.data(_cmd);
                
                    dataGridView1.DataSource = dt;
                }
            
        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
