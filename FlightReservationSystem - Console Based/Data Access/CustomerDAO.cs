using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FlightReservationSystem.Entities;

namespace FlightReservationSystem.Data_Access
{
    internal class CustomerDAO
    {
        static string GetInsertStatement(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string tableName = type.Name;

            // Filter out the unwanted property
            properties = properties.Where(p => p.Name != "phone").ToArray();

            string columns = string.Join(", ", properties.Select(p => p.Name));
            string values = string.Join(", ", properties.Select(p => "@" + p.Name));
            return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        }
        static string GenerateUpdateStatement(object obj)
        {
            string tableName = obj.GetType().Name;
            string updateStatement = "UPDATE " + tableName + " SET ";
            PropertyInfo[] properties = obj.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name != "CustomerID" && properties[i].Name != "phone")
                {
                    updateStatement += properties[i].Name + " = @" + properties[i].Name;
                    if (i < properties.Length - 2)
                    {
                        updateStatement += ", ";
                    }
                }
            }
            updateStatement += " WHERE CustomerID = @Id";
            return updateStatement;
        }
        public static List<Customer> getCustomers()
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            List<Customer> customers = new List<Customer>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Customer", con);

            using (SqlDataReader reader = command.ExecuteReader()) // Like a while loop
            {
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerID = reader.GetInt32(0),
                        fname = reader.GetString(1),
                        lname = reader.GetString(2),
                        gender = reader.GetString(3),
                        DataOfBirth = reader.GetDateTime(4),
                        email = reader.GetString(5),
                        password = reader.GetString(6)
                    };
                    customers.Add(customer);
                }
            }

            con.Close();
            return customers;
        }

        public static void insertCustomer(Customer customer)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string sql = GetInsertStatement(customer);

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var property in customer.GetType().GetProperties())
                {
                    command.Parameters.AddWithValue("@" + property.Name, property.GetValue(customer));
                }

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected);
                connection.Close();
            }

        }

        public static bool ValidateCredentials(string email, string password)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string sql = "SELECT COUNT(*) FROM Customer WHERE Email = @Email AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return count > 0;
            }
        }
        public static Customer getCustomer(string customerEmail)
        {
            string sql = "SELECT * FROM Customer WHERE email = @email";
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@email", customerEmail);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Customer customer = new Customer
                    {
                        CustomerID = reader.GetInt32(0),
                        fname = reader.GetString(1),
                        lname = reader.GetString(2),
                        gender = reader.GetString(3),
                        DataOfBirth = reader.GetDateTime(4),
                        email = reader.GetString(5),
                        password = reader.GetString(6)
                    };
                    return customer;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void updateCustomer(Customer customer)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string sql = GenerateUpdateStatement(customer);
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var property in customer.GetType().GetProperties())
                {
                    if (property.Name != "CustomerID" && property.Name != "phone")
                    {
                        command.Parameters.AddWithValue("@" + property.Name, property.GetValue(customer));
                    }
                }
                command.Parameters.AddWithValue("@Id", customer.CustomerID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " rows updated");
                connection.Close();
            }
        }


        public static List<Customer> GetCustomersWithPhones()
        {
            // Define the SQL query to join the Customer and Customer_Phone tables
            string query = "SELECT c.CustomerID, c.fname, c.lname, c.gender, c.DataOfBirth, c.email, cp.phone " +
                           "FROM Customer c " +
                           "INNER JOIN Customer_Phone cp ON c.CustomerID = cp.CustomerID " +
                           "ORDER BY c.CustomerID";

            // Create a new list to hold the results
            List<Customer> customersWithPhones = new List<Customer>();

            try
            {
                // Create a new SqlConnection object with your connection string
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;"))
                {
                    // Create a new SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query and retrieve the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Loop through the results and create a new Customer object for each row
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerID = reader.GetInt32(0),
                                    fname = reader.GetString(1),
                                    lname = reader.GetString(2),
                                    gender = reader.GetString(3),
                                    DataOfBirth = reader.GetDateTime(4),
                                    email = reader.GetString(5),
                                    phone = reader.GetString(6),
                                };
                               

                                // Add the customer to the list
                                customersWithPhones.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error getting customers with phones: " + ex.Message);
            }

            // Return the list of customers with phones
            return customersWithPhones;
        }

    }
}
