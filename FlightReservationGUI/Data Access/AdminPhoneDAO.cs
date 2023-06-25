using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FlightReservationSystem.Data_Access
{
    internal class AdminPhoneDAO
    {
        public static void addAdminPhone(int adminId, string phone)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "INSERT INTO Admin_Phone (phone, AdminID) VALUES (@phone, @adminId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@adminId", adminId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("New Admin phone added successfully. Rows affected: {0}", rowsAffected);
            }
        }
    }
}
