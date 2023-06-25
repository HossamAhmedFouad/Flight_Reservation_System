using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FlightReservationSystem.Entities;

namespace FlightReservationSystem.Data_Access
{
    internal class AdminDAO
    {
        static string GetInsertStatement(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string tableName = type.Name;
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
                if (properties[i].Name != "AdminID")
                {
                    updateStatement += properties[i].Name + " = @" + properties[i].Name;
                    if (i < properties.Length - 1)
                    {
                        updateStatement += ", ";
                    }
                }
            }
            updateStatement += " WHERE AdminID = @Id";
            return updateStatement;
        }
        public static List<Admin> getAdmins()
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            List<Admin> admins = new List<Admin>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Admin", con);

            using (SqlDataReader reader = command.ExecuteReader()) // Like a while loop
            {
                while (reader.Read())
                {
                    Admin admin = new Admin
                    {
                        AdminID = reader.GetInt32(0),
                        fname = reader.GetString(1),
                        lname = reader.GetString(2),
                        gendar = reader.GetString(3),
                        dateOfBirth = reader.GetDateTime(4),
                        email = reader.GetString(5),
                        age = reader.GetInt32(6),
                        PASSWORD = reader.GetString(7)
                    };
                    admins.Add(admin);
                }
            }
            con.Close();
            return admins;
        }

        public static void insertAdmin(Admin admin)
        {

            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string sql = GetInsertStatement(admin);

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var property in admin.GetType().GetProperties())
                {
                    command.Parameters.AddWithValue("@" + property.Name, property.GetValue(admin));
                }

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected);
                connection.Close();
            }
        }

        public static bool ValidateCredentials(string email,string password)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string sql = "SELECT COUNT(*) FROM Admin WHERE Email = @Email AND Password = @Password";
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
        public static Admin getAdmin(string adminEmail)
        {
            string sql = "SELECT * FROM Admin WHERE email = @email";
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@email", adminEmail);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Admin admin = new Admin
                    {
                        AdminID = reader.GetInt32(0),
                        fname = reader.GetString(1),
                        lname = reader.GetString(2),
                        gendar = reader.GetString(3),
                        dateOfBirth = reader.GetDateTime(4),
                        email = reader.GetString(5),
                        age = reader.GetInt32(6),
                        PASSWORD = reader.GetString(7)
                    };
                    return admin;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void updateAdmin(Admin admin)
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string sql = GenerateUpdateStatement(admin);
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var property in admin.GetType().GetProperties())
                {
                    if (property.Name != "AdminID")
                    {
                        command.Parameters.AddWithValue("@" + property.Name, property.GetValue(admin));
                    }
                }
                command.Parameters.AddWithValue("@Id", admin.AdminID);
                Console.WriteLine($"Admin is is {admin.AdminID}");
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " rows updated");
                connection.Close();
            }
        }
    }
}
