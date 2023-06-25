using FlightReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data_Access
{
    internal class AircraftDAO
    {

    public static int GetMaxAircraftId()
    {
        int maxAircraftId = 0;

        using (SqlConnection connection = new SqlConnection("Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;"))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MAX(aircraftID) FROM Aircraft", connection);
            object result = command.ExecuteScalar();

            if (result != DBNull.Value)
            {
                maxAircraftId = Convert.ToInt32(result);
            }
        }

        return maxAircraftId;
    }
    public static List<Aircraft> getAllAircrafts()
        {
            List<Aircraft> aircrafts = new List<Aircraft>();

            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "SELECT AircraftID, Model, Color, Capacity FROM Aircraft";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Aircraft aircraft = new Aircraft();
                    aircraft.AircraftId = reader.GetInt32(0);
                    aircraft.Model = reader.GetString(1);
                    aircraft.Color = reader.IsDBNull(2) ? null : reader.GetString(2);
                    aircraft.Capacity = reader.GetInt32(3);

                    aircrafts.Add(aircraft);
                }

                reader.Close();
            }

            return aircrafts;
        }
        public static void addNewAircraft(Aircraft newAircraft)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "INSERT INTO Aircraft (AircraftID, Model, Color, Capacity) VALUES (@AircraftID, @Model, @Color, @Capacity)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AircraftID", newAircraft.AircraftId);
                command.Parameters.AddWithValue("@Model", newAircraft.Model);
                command.Parameters.AddWithValue("@Color", string.IsNullOrEmpty(newAircraft.Color) ? (object)DBNull.Value : newAircraft.Color);
                command.Parameters.AddWithValue("@Capacity", newAircraft.Capacity);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("New aircraft added successfully. Rows affected: {0}", rowsAffected);
            }
        }
        public static void updateAircraft(Aircraft updatedAircraft)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "UPDATE Aircraft SET Model = @Model, Color = @Color, Capacity = @Capacity WHERE AircraftID = @AircraftID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AircraftID", updatedAircraft.AircraftId);
                command.Parameters.AddWithValue("@Model", updatedAircraft.Model);
                command.Parameters.AddWithValue("@Color", string.IsNullOrEmpty(updatedAircraft.Color) ? (object)DBNull.Value : updatedAircraft.Color);
                command.Parameters.AddWithValue("@Capacity", updatedAircraft.Capacity);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Aircraft updated successfully. Rows affected: {0}", rowsAffected);
            }
        }


        public static void DeleteAircraft(int aircraftID)
        {
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to delete the aircraft with the specified ID
            string query = "DELETE FROM Aircraft WHERE aircraftID = @AircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand object with the query and the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter for the aircraft ID to the command
                    command.Parameters.AddWithValue("@AircraftID", aircraftID);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
