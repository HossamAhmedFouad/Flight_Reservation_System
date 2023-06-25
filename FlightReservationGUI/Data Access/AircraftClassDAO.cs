using FlightReservationSystem.Entities;
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


        public static List<Aircraft_Class> GetAircraftClasses()
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to select all records from the Aircraft_Class table
            string query = "SELECT Class, AircraftID FROM Aircraft_Class";

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
                        // Create a list to store the Aircraft_Class objects
                        List<Aircraft_Class> aircraftClasses = new List<Aircraft_Class>();

                        // Loop through the rows in the result set and create a new Aircraft_Class object for each row
                        while (reader.Read())
                        {
                            Aircraft_Class aircraftClass = new Aircraft_Class();
                            aircraftClass.Class = reader.GetString(0);
                            aircraftClass.AircraftID = reader.GetInt32(1);
                            aircraftClasses.Add(aircraftClass);
                        }

                        // Return the list of Aircraft_Class objects
                        return aircraftClasses;
                    }
                }
            }
        }

        public static void UpdateAircraftClass(Aircraft_Class aircraftClass)
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to update the record in the Aircraft_Class table with the specified AircraftID
            string query = "UPDATE Aircraft_Class SET Class = @Class WHERE AircraftID = @AircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters for the Aircraft_Class object to the command
                    command.Parameters.AddWithValue("@Class", aircraftClass.Class);
                    command.Parameters.AddWithValue("@AircraftID", aircraftClass.AircraftID);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAircraftClass(int aircraftID)
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to delete the record with the specified AircraftID from the Aircraft_Class table
            string query = "DELETE FROM Aircraft_Class WHERE AircraftID = @AircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter for the AircraftID to the command
                    command.Parameters.AddWithValue("@AircraftID", aircraftID);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
