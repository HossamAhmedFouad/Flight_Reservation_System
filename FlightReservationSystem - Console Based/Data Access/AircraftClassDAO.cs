using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data_Access
{
    internal class AircraftClassDAO
    {
        public static void AddAircraftToClass(string aircraftClass, int aircraftId)
        {
            // Define the SQL query to insert a new row into the Aircraft_Class table
            string query = "INSERT INTO Aircraft_Class (class, aircraftID) VALUES (@class, @aircraftID)";

            try
            {
                // Create a new SqlConnection object with your connection string
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;"))
                {
                    // Create a new SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Set the parameters for the command
                        command.Parameters.AddWithValue("@class", aircraftClass);
                        command.Parameters.AddWithValue("@aircraftID", aircraftId);

                        // Open the connection
                        connection.Open();

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error adding aircraft to class: " + ex.Message);
            }
        }
    }
}
