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
using System.Net.Mail;

namespace Appointment
{
    public partial class AddAppointment : Form
    {
        List<ClientAdd> ca = new List<ClientAdd>();

        List<AddDoctor> da = new List<AddDoctor>();

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


        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {


            string query = " SELECT * FROM CLIENT_TABLE";

            using (SqlCommand _cmd = new SqlCommand(query))
            {



                DataTable dt = new DataTable();
                dt = (DataTable)datatable.data(_cmd);



                foreach (DataRow row in dt.Rows)
                {
                    ClientAdd obj = new ClientAdd();


                    obj.client_name = row["first_name"].ToString();
                    obj.client_id = Convert.ToInt64(row["client_id"]);

                    ca.Add(obj);

                    comboBox1.Items.Add(row["first_name"].ToString());


                }


            }



            string quey2 = "SELECT * FROM DOCTOR";
            using (SqlCommand _cmd = new SqlCommand(quey2))
            {

                DataTable dt = new DataTable();
                dt = (DataTable)datatable.data(_cmd);


                foreach (DataRow row in dt.Rows)
                {
                    AddDoctor obj = new AddDoctor();
                    obj.doctor_name = row["doctor_name"].ToString();
                    obj.doctor_id = Convert.ToInt32(row["doctor_id"]);

                    da.Add(obj);
                    comboBox2.Items.Add(row["doctor_name"].ToString());

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
            client_id = comboBox1.SelectedIndex + 1;
           doctor_id = comboBox2.SelectedIndex + 1;

            
            date = dateTimePicker1.Value;
            time = dateTimePicker2.Value;
            string clientEmail = string.Empty;


                 string connectioString = database.connectionString;
            using (SqlConnection _con = new SqlConnection(connectioString))
            {
          
                string emailQuery = "SELECT EMAIL FROM CLIENT_TABLE WHERE CLIENT_ID = @client_id";
                using (SqlCommand emailCmd = new SqlCommand(emailQuery, _con))
                {
                    emailCmd.Parameters.AddWithValue("@client_id", client_id);
                    _con.Open();
                    SqlDataReader reader = emailCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        clientEmail = reader["EMAIL"].ToString();
                    }
                    reader.Close();
                    _con.Close();
                }
            }



                string query = "INSERT INTO APPOINTMENT_TABLE(CLIENT_ID, DOCTOR_ID, APPOINTMENT_DATE, APPOINTMENT_TIME) VALUES(@client_id, @doctor_id, @date, @time)";


            try { 
            using (SqlCommand _cmd = new SqlCommand(query))
            {
                _cmd.Parameters.AddWithValue("@client_id", client_id);
                _cmd.Parameters.AddWithValue("@doctor_id", doctor_id);
                _cmd.Parameters.AddWithValue("@date", date);
                _cmd.Parameters.AddWithValue("@time", time);

                int isWorking = (int)datatable.data(_cmd);


                if (isWorking > 0)
                {
                    MessageBox.Show("Appointment Scheduled Successfully");
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    dateTimePicker1.ResetText();
                    dateTimePicker2.ResetText();

                        // Step 3: Send Email Notification
                        /*      if (!string.IsNullOrEmpty(clientEmail))
                              {
                                  SendEmail(clientEmail, date, time);
                              }
                              else
                              {
                                  MessageBox.Show("Client email not found. Email notification skipped.");
                              }*/

                        SendEmail(clientEmail, date, time);

                }
                else
                {
                    MessageBox.Show("Data is not Inserted");
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }
        }

        // send email function
        private void SendEmail(string clientEmail, DateTime date, DateTime time)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kaustubhpatil1211@gmail.com"); 
                mail.To.Add(clientEmail);
                mail.Subject = "Appointment Confirmation";
                mail.Body = $"Dear Client,\n\nYour appointment has been successfully scheduled for {date.ToShortDateString()} at {time.ToShortTimeString()}.\n\nThank you.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com"); 
                smtp.Port = 587; 
                smtp.Credentials = new System.Net.NetworkCredential("kaustubhpatil1211@gmail.com", "bskd quva luuy ybbf"); 
                smtp.EnableSsl = true; 

                smtp.Send(mail);
                MessageBox.Show("Email notification sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SMTP Error: {ex.Message}\nStatus Code: \nStackTrace: {ex.StackTrace}");
            }
        }



        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
