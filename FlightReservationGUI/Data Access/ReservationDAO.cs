using FlightReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data_Access
{
    internal class ReservationDAO
    {
       public static List<Reservation> getAllReservations()
       {
            List<Reservation> reservations = new List<Reservation>();

            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "SELECT * FROM Reservation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation();
                    reservation.CustomerID = (int)reader["CustomerID"];
                    reservation.FlightID = (int)reader["FlightID"];
                    reservation.seatNumber = (int)reader["seatNumber"];
                    reservation.Price = (float)reader["price"];
                    reservation.Class = (string)reader["class"];
                    reservation.Type = (string)reader["type"];
                    reservation.State = (string)reader["state"];

                    reservations.Add(reservation);
                }

                reader.Close();
            }

            return reservations;
       }

        public static List<Reservation> getAllReservationsByCustomerId(int customerId)
        {
            List<Reservation> reservations = new List<Reservation>();

            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "SELECT * FROM Reservation WHERE CustomerID = @CustomerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation();
                    reservation.CustomerID = (int)reader["CustomerID"];
                    reservation.FlightID = (int)reader["FlightID"];
                    reservation.seatNumber = (int)reader["seatNumber"];
                    reservation.Price = (float)reader["price"];
                    reservation.Class = (string)reader["class"];
                    reservation.Type = (string)reader["type"];
                    reservation.State = (string)reader["state"];

                    reservations.Add(reservation);
                }

                reader.Close();
                connection.Close();
            }
            return reservations;
        }

        public static void insertReservation(Reservation newReservation)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "INSERT INTO Reservation (CustomerID, FlightID, seatNumber, price, class, type, state) VALUES (@CustomerID, @FlightID, @seatNumber, @Price, @Class, @Type, @State)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", newReservation.CustomerID);
                command.Parameters.AddWithValue("@FlightID", newReservation.FlightID);
                command.Parameters.AddWithValue("@seatNumber", newReservation.seatNumber);
                command.Parameters.AddWithValue("@Price", newReservation.Price);
                command.Parameters.AddWithValue("@Class", newReservation.Class);
                command.Parameters.AddWithValue("@Type", newReservation.Type);
                command.Parameters.AddWithValue("@State", newReservation.State);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("New reservation added successfully. Rows affected: {0}", rowsAffected);
                connection.Close();
            }
        }

        public static void updateReservation(int customerId, int flightId, int seatNumber, Reservation newReservation)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "UPDATE Reservation SET CustomerID = @NewCustomerId, FlightID = @NewFlightId, seatNumber = @NewSeatNumber, price = @NewPrice, class = @NewClass, type = @NewType, state = @NewState WHERE CustomerID = @CustomerId AND FlightID = @FlightId AND seatNumber = @SeatNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewCustomerId", newReservation.CustomerID);
                command.Parameters.AddWithValue("@NewFlightId", newReservation.FlightID);
                command.Parameters.AddWithValue("@NewSeatNumber", newReservation.seatNumber);
                command.Parameters.AddWithValue("@NewPrice", newReservation.Price);
                command.Parameters.AddWithValue("@NewClass", newReservation.Class);
                command.Parameters.AddWithValue("@NewType", newReservation.Type);
                command.Parameters.AddWithValue("@NewState", newReservation.State);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@FlightId", flightId);
                command.Parameters.AddWithValue("@SeatNumber", seatNumber);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Reservation updated successfully. Rows affected: {0}", rowsAffected);
                connection.Close();
            }
        }
        public static void deleteReservation(int customerId, int flightId, int seatNumber)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "DELETE FROM Reservation WHERE CustomerID = @CustomerId AND FlightID = @FlightId AND seatNumber = @SeatNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@FlightId", flightId);
                command.Parameters.AddWithValue("@SeatNumber", seatNumber);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Reservation deleted successfully. Rows affected: {0}", rowsAffected);
            }
        }
    }
}
