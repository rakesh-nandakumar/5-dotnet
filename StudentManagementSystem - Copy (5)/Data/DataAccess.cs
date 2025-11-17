using System.Data;
using System.Data.SqlClient;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    /// <summary>
    /// Static data access class for database operations
    /// Version 5 (Corporate Formal) characteristic - Static class approach
    /// </summary>
    public static class DataAccess
    {
        // Static connection string - Corporate style with full server details
        private static readonly string connectionString = @"Server=DESKTOP-F2PGMGH\SQLEXPRESS03;Database=Student;Trusted_Connection=True;TrustServerCertificate=True";

        /// <summary>
        /// Opens and returns a new database connection
        /// </summary>
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Tests the database connection availability
        /// </summary>
        public static bool TestDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates user credentials for authentication
        /// </summary>
        public static bool ValidateUserCredentials(string usernameValue, string passwordValue)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string queryCommand = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";

                    using (SqlCommand command = new SqlCommand(queryCommand, connection))
                    {
                        command.Parameters.AddWithValue("@username", usernameValue);
                        command.Parameters.AddWithValue("@password", passwordValue);

                        int recordCount = (int)command.ExecuteScalar();
                        return recordCount > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a registration number already exists in the database
        /// </summary>
        public static bool CheckRegistrationNumberExists(int registrationNumber)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string queryCommand = "SELECT COUNT(*) FROM Registration WHERE regNo = @regNo";

                    using (SqlCommand command = new SqlCommand(queryCommand, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", registrationNumber);
                        int recordCount = (int)command.ExecuteScalar();
                        return recordCount > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts a new student record into the database
        /// </summary>
        public static bool InsertStudentRecord(Student studentData)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string insertCommand = @"INSERT INTO Registration 
                        (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, parentName, nic, contactNo) 
                        VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @homePhone, @parentName, @nic, @contactNo)";

                    using (SqlCommand command = new SqlCommand(insertCommand, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", studentData.RegNo);
                        command.Parameters.AddWithValue("@firstName", studentData.FirstName);
                        command.Parameters.AddWithValue("@lastName", studentData.LastName);
                        command.Parameters.AddWithValue("@dateOfBirth", studentData.DateOfBirth);
                        command.Parameters.AddWithValue("@gender", studentData.Gender);
                        command.Parameters.AddWithValue("@address", studentData.Address);
                        command.Parameters.AddWithValue("@email", studentData.Email);
                        command.Parameters.AddWithValue("@mobilePhone", studentData.MobilePhone);
                        command.Parameters.AddWithValue("@homePhone", studentData.HomePhone);
                        command.Parameters.AddWithValue("@parentName", studentData.ParentName);
                        command.Parameters.AddWithValue("@nic", studentData.NIC);
                        command.Parameters.AddWithValue("@contactNo", studentData.ContactNo);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Updates an existing student record in the database
        /// </summary>
        public static bool UpdateStudentRecord(Student studentData)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string updateCommand = @"UPDATE Registration SET 
                        firstName = @firstName, 
                        lastName = @lastName, 
                        dateOfBirth = @dateOfBirth, 
                        gender = @gender, 
                        address = @address, 
                        email = @email, 
                        mobilePhone = @mobilePhone, 
                        homePhone = @homePhone, 
                        parentName = @parentName, 
                        nic = @nic, 
                        contactNo = @contactNo 
                        WHERE regNo = @regNo";

                    using (SqlCommand command = new SqlCommand(updateCommand, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", studentData.RegNo);
                        command.Parameters.AddWithValue("@firstName", studentData.FirstName);
                        command.Parameters.AddWithValue("@lastName", studentData.LastName);
                        command.Parameters.AddWithValue("@dateOfBirth", studentData.DateOfBirth);
                        command.Parameters.AddWithValue("@gender", studentData.Gender);
                        command.Parameters.AddWithValue("@address", studentData.Address);
                        command.Parameters.AddWithValue("@email", studentData.Email);
                        command.Parameters.AddWithValue("@mobilePhone", studentData.MobilePhone);
                        command.Parameters.AddWithValue("@homePhone", studentData.HomePhone);
                        command.Parameters.AddWithValue("@parentName", studentData.ParentName);
                        command.Parameters.AddWithValue("@nic", studentData.NIC);
                        command.Parameters.AddWithValue("@contactNo", studentData.ContactNo);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a student record from the database
        /// </summary>
        public static bool DeleteStudentRecord(int registrationNumber)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string deleteCommand = "DELETE FROM Registration WHERE regNo = @regNo";

                    using (SqlCommand command = new SqlCommand(deleteCommand, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", registrationNumber);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves a student record by registration number
        /// </summary>
        public static Student? GetStudentRecordByRegistrationNumber(int registrationNumber)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string selectCommand = "SELECT * FROM Registration WHERE regNo = @regNo";

                    using (SqlCommand command = new SqlCommand(selectCommand, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", registrationNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Student
                                {
                                    RegNo = (int)reader["regNo"],
                                    FirstName = reader["firstName"].ToString() ?? string.Empty,
                                    LastName = reader["lastName"].ToString() ?? string.Empty,
                                    DateOfBirth = (DateTime)reader["dateOfBirth"],
                                    Gender = reader["gender"].ToString() ?? string.Empty,
                                    Address = reader["address"].ToString() ?? string.Empty,
                                    Email = reader["email"].ToString() ?? string.Empty,
                                    MobilePhone = int.TryParse(reader["mobilePhone"].ToString(), out int mob) ? mob : 0,
                                    HomePhone = int.TryParse(reader["homePhone"].ToString(), out int home) ? home : 0,
                                    ParentName = reader["parentName"].ToString() ?? string.Empty,
                                    NIC = reader["nic"].ToString() ?? string.Empty,
                                    ContactNo = int.TryParse(reader["contactNo"].ToString(), out int contact) ? contact : 0
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                // Log error in production environment
            }

            return null;
        }

        /// <summary>
        /// Retrieves all registration numbers from the database
        /// </summary>
        public static List<int> GetAllRegistrationNumbers()
        {
            List<int> registrationNumberList = new List<int>();

            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string selectCommand = "SELECT regNo FROM Registration ORDER BY regNo";

                    using (SqlCommand command = new SqlCommand(selectCommand, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registrationNumberList.Add((int)reader["regNo"]);
                            }
                        }
                    }
                }
            }
            catch
            {
                // Log error in production environment
            }

            return registrationNumberList;
        }
    }
}
