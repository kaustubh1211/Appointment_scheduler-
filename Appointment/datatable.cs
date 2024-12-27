using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Appointment
{
    public static class datatable
    {
        public static string connection = database.connectionString;

        public static object data(SqlCommand cmd   )
        {
            using (SqlConnection _con = new SqlConnection(connection))
            {
                cmd.Connection = _con;
                // for select 

                if (cmd.CommandText.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                {
             
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(cmd);

                    _con.Open();
                    _dap.Fill(dt);
                    _con.Close();

                    return dt;
                }
                else
                {
                    // for insert , update
                    _con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    _con.Close();

                    return rowsAffected;
                }

            }
        }
    }
}
