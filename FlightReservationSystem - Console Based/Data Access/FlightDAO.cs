using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FlightReservationSystem.Entities;

namespace FlightReservationSystem
{
    internal class FlightDAO
    {
        public static List<Flight> getFlights()
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            List<Flight> flights = new List<Flight>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Flight", con);

            using (SqlDataReader reader = command.ExecuteReader()) // Like a while loop
            {
                while (reader.Read())
                {
                    Flight flight = new Flight
                    {
                        FlightId = reader.GetInt32(0),
                        aircraftId = reader.GetInt32(1),
                        source = reader.GetString(2),
                        destination = reader.GetString(3),
                        arrivalDate = reader.GetDateTime(4),
                        arrivalTime = reader.GetDateTime(5),
                        departureDate = reader.GetDateTime(6),
                        departureTime = reader.GetDateTime(7),
                        state = reader.GetString(8),
                        requiredNumberOfSeats = reader.GetInt32(9)
                    };
                    flights.Add(flight);
                }
            }

            con.Close();

            return flights;
        }
        public static List<Flight> search(string text)
        {
            List<Flight> flights = new List<Flight>();
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            string searchWildPhrase = "%" + text + "%";
            command.CommandText = "SELECT * FROM Flight WHERE flightID LIKE @text";
            command.Parameters.AddWithValue("@text", searchWildPhrase);
            command.Connection = con;

            using (SqlDataReader reader = command.ExecuteReader()) // Like a while loop
            {
                while (reader.Read())
                {
                    Flight flight = new Flight
                    {
                        FlightId = reader.GetInt32(0),
                        aircraftId = reader.GetInt32(1),
                        source = reader.GetString(2),
                        destination = reader.GetString(3),
                        arrivalDate = reader.GetDateTime(4),
                        arrivalTime = reader.GetDateTime(5),
                        departureDate = reader.GetDateTime(6),
                        departureTime = reader.GetDateTime(7),
                        state = reader.GetString(8),
                        requiredNumberOfSeats = reader.GetInt32(9)
                    };
                    flights.Add(flight);
                }
            }

            con.Close();

            return flights;
        }

        public static void addNewFlight(Flight newFlight)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "INSERT INTO Flight (FlightID, aircraftID, source, destination, arrivalDate, arrivalTime, depatureDate, depatureTime, state, requiredNumberOfSeats) VALUES (@FlightID, @aircraftID, @source, @destination, @arrivalDate, @arrivalTime, @depatureDate, @depatureTime, @state, @requiredNumberOfSeats)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FlightID", newFlight.FlightId);
                command.Parameters.AddWithValue("@aircraftID", newFlight.aircraftId);
                command.Parameters.AddWithValue("@source", newFlight.source);
                command.Parameters.AddWithValue("@destination", newFlight.destination);
                command.Parameters.AddWithValue("@arrivalDate", newFlight.arrivalDate);
                command.Parameters.AddWithValue("@arrivalTime", newFlight.arrivalTime);
                command.Parameters.AddWithValue("@depatureDate", newFlight.departureDate);
                command.Parameters.AddWithValue("@depatureTime", newFlight.departureTime);
                command.Parameters.AddWithValue("@state", newFlight.state);
                command.Parameters.AddWithValue("@requiredNumberOfSeats", newFlight.requiredNumberOfSeats);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("New flight added successfully. Rows affected: {0}", rowsAffected);
            }
        }

        public static void updateFlight(Flight updatedFlight)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "UPDATE Flight SET aircraftID = @aircraftID, source = @source, destination = @destination, arrivalDate = @arrivalDate, arrivalTime = @arrivalTime, depatureDate = @depatureDate, depatureTime = @depatureTime, state = @state, requiredNumberOfSeats = @requiredNumberOfSeats WHERE FlightID = @FlightID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FlightID", updatedFlight.FlightId);
                command.Parameters.AddWithValue("@aircraftID", updatedFlight.aircraftId);
                command.Parameters.AddWithValue("@source", updatedFlight.source);
                command.Parameters.AddWithValue("@destination", updatedFlight.destination);
                command.Parameters.AddWithValue("@arrivalDate", updatedFlight.arrivalDate);
                command.Parameters.AddWithValue("@arrivalTime", updatedFlight.arrivalTime);
                command.Parameters.AddWithValue("@depatureDate", updatedFlight.departureDate);
                command.Parameters.AddWithValue("@depatureTime", updatedFlight.departureTime);
                command.Parameters.AddWithValue("@state", updatedFlight.state);
                command.Parameters.AddWithValue("@requiredNumberOfSeats", updatedFlight.requiredNumberOfSeats);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Flight updated successfully. Rows affected: {0}", rowsAffected);
            }
        }

        public static List<Flight> getFlightsBySource(string source)
        {
            List<Flight> flights = new List<Flight>();
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Flight WHERE source LIKE @source";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@source", "%" + source + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Flight flight = new Flight();
                    flight.FlightId = (int)reader["FlightID"];
                    flight.aircraftId = (int)reader["aircraftID"];
                    flight.source = (string)reader["source"];
                    flight.destination = (string)reader["destination"];
                    flight.arrivalDate = (DateTime)reader["arrivalDate"];
                    flight.arrivalTime = (DateTime)reader["arrivalTime"];
                    flight.departureDate = (DateTime)reader["depatureDate"];
                    flight.departureTime = (DateTime)reader["depatureTime"];
                    flight.state = (string)reader["state"];
                    flight.requiredNumberOfSeats = (int)reader["requiredNumberOfSeats"];

                    flights.Add(flight);
                }

                reader.Close();
                connection.Close();
            }

            return flights;
        }
        public static List<Flight> getFlightsByDestination(string destination)
        {
            List<Flight> flights = new List<Flight>();
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Flight WHERE destination LIKE @destination";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@destination", "%" + destination + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Flight flight = new Flight();
                    flight.FlightId = (int)reader["FlightID"];
                    flight.aircraftId = (int)reader["aircraftID"];
                    flight.source = (string)reader["source"];
                    flight.destination = (string)reader["destination"];
                    flight.arrivalDate = (DateTime)reader["arrivalDate"];
                    flight.arrivalTime = (DateTime)reader["arrivalTime"];
                    flight.departureDate = (DateTime)reader["depatureDate"];
                    flight.departureTime = (DateTime)reader["depatureTime"];
                    flight.state = (string)reader["state"];
                    flight.requiredNumberOfSeats = (int)reader["requiredNumberOfSeats"];

                    flights.Add(flight);
                }

                reader.Close();
                connection.Close();
            }

            return flights;
        }

        public static List<Flight> getFlightsByDate(DateTime date)
        {
            List<Flight> flights = new List<Flight>();
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Flight WHERE CAST(arrivalDate AS DATE) = @date OR CAST(depatureDate AS DATE) = @date";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date.Date);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Flight flight = new Flight();
                    flight.FlightId = (int)reader["FlightID"];
                    flight.aircraftId = (int)reader["aircraftID"];
                    flight.source = (string)reader["source"];
                    flight.destination = (string)reader["destination"];
                    flight.arrivalDate = (DateTime)reader["arrivalDate"];
                    flight.arrivalTime = (DateTime)reader["arrivalTime"];
                    flight.departureDate = (DateTime)reader["depatureDate"];
                    flight.departureTime = (DateTime)reader["depatureTime"];
                    flight.state = (string)reader["state"];
                    flight.requiredNumberOfSeats = (int)reader["requiredNumberOfSeats"];

                    flights.Add(flight);
                }

                reader.Close();
            }

            return flights;
        }

        public static List<Flight> getFlightsByRequiredSeats(int requiredSeats)
        {
            List<Flight> flights = new List<Flight>();
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Flight WHERE requiredNumberOfSeats >= @requiredSeats";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@requiredSeats", requiredSeats);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Flight flight = new Flight();
                    flight.FlightId = (int)reader["FlightID"];
                    flight.aircraftId = (int)reader["aircraftID"];
                    flight.source = (string)reader["source"];
                    flight.destination = (string)reader["destination"];
                    flight.arrivalDate = (DateTime)reader["arrivalDate"];
                    flight.arrivalTime = (DateTime)reader["arrivalTime"];
                    flight.departureDate = (DateTime)reader["depatureDate"];
                    flight.departureTime = (DateTime)reader["depatureTime"];
                    flight.state = (string)reader["state"];
                    flight.requiredNumberOfSeats = (int)reader["requiredNumberOfSeats"];

                    flights.Add(flight);
                }

                reader.Close();
            }

            return flights;
        }
    }
}
