using FlightReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data_Access
{
    internal class ManageAircraftDAO
    {
        
        public static List<ManageAircraft> GetManageAircraft()
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to select all records from the manageAircraft table
            string query = "SELECT AdminID, AircraftID FROM manageAircraft";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get the results in a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a list to store the ManageAircraft objects
                        List<ManageAircraft> manageAircraftList = new List<ManageAircraft>();

                        // Loop through the rows in the result set and create a new ManageAircraft object for each row
                        while (reader.Read())
                        {
                            ManageAircraft manageAircraftObj = new ManageAircraft();
                            manageAircraftObj.AdminID = reader.GetInt32(0);
                            manageAircraftObj.AircraftID = reader.GetInt32(1);
                            manageAircraftList.Add(manageAircraftObj);
                        }

                        // Return the list of ManageAircraft objects
                        return manageAircraftList;
                    }
                }
            }
        }

        public static void UpdateManageAircraft(ManageAircraft manageAircraft)
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to update the record in the manageAircraft table with the specified AdminID and AircraftID
            string query = "UPDATE manageAircraft SET AdminID = @AdminID WHERE AircraftID = @AircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters for the ManageAircraft object to the command
                    command.Parameters.AddWithValue("@AdminID", manageAircraft.AdminID);
                    command.Parameters.AddWithValue("@AircraftID", manageAircraft.AircraftID);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteManageAircraft(int adminID, int aircraftID)
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to delete the record from the manageAircraft table with the specified AdminID and AircraftID
            string query = "DELETE FROM manageAircraft WHERE AdminID = @AdminID AND AircraftID = @AircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters for the AdminID and AircraftID to the command
                    command.Parameters.AddWithValue("@AdminID", adminID);
                    command.Parameters.AddWithValue("@AircraftID", aircraftID);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void InsertManageAircraft(ManageAircraft manageAircraft)
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to insert the new record into the manageAircraft table
            string query = "INSERT INTO manageAircraft (AdminID, AircraftID) VALUES (@AdminID, @AircraftID)";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters for the ManageAircraft object to the command
                    command.Parameters.AddWithValue("@AdminID", manageAircraft.AdminID);
                    command.Parameters.AddWithValue("@AircraftID", manageAircraft.AircraftID);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
