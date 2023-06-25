using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Data_Access
{
    internal class CustomerPhoneDAO
    {
        public static void addCustomerPhone(int customerId, string phone)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = "INSERT INTO Customer_Phone (phone, CustomerID) VALUES (@phone, @customerId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@customerId", customerId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("New Customer phone added successfully. Rows affected: {0}", rowsAffected);
            }
        }
        public static void DeleteCustomerPhone(string phone, int customerID)
        {
            // Define the SQL DELETE statement to remove the phone number for the specified customer
            string query = "DELETE FROM Customer_Phone WHERE phone = @phone AND CustomerID = @customerID";

            try
            {
                // Create a new SqlConnection object with your connection string
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;"))
                {
                    // Create a new SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the phone and customer ID parameters to the command
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@customerID", customerID);

                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Phone number {0} for customer {1} has been deleted.", phone, customerID);
                        }
                        else
                        {
                            Console.WriteLine("No phone number was found for customer {0}.", customerID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error deleting customer phone number:" + ex.Message);
            }
        }
    }
}
