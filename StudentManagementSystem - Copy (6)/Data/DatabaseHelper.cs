using System.Data;
using System.Data.SqlClient;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class DatabaseHelper
    {
        // Connection string - Update YOUR_SERVER with your SQL Server instance
        // Common values: "localhost", ".\\SQLEXPRESS", "(localdb)\\MSSQLLocalDB"
        private string connectionString = @"Server=DESKTOP-F2PGMGH\SQLEXPRESS03;Database=Student;Trusted_Connection=True";

        // Get database connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Test database connection
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Validate user login
        public bool ValidateUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Check if registration number exists
        public bool RegNoExists(int regNo)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", regNo);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Insert student record
        public bool InsertStudent(Student student)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Registration (regNo, firstName, lastName, dateOfBirth, gender, 
                                   address, email, mobilePhone, homePhone, parentName, nic, contactNo) 
                                   VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, 
                                   @address, @email, @mobilePhone, @homePhone, @parentName, @nic, @contactNo)";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", student.RegNo);
                        cmd.Parameters.AddWithValue("@firstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", student.LastName);
                        cmd.Parameters.AddWithValue("@dateOfBirth", student.DateOfBirth);
                        cmd.Parameters.AddWithValue("@gender", student.Gender);
                        cmd.Parameters.AddWithValue("@address", student.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", student.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@mobilePhone", student.MobilePhone);
                        cmd.Parameters.AddWithValue("@homePhone", student.HomePhone);
                        cmd.Parameters.AddWithValue("@parentName", student.ParentName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@nic", student.NIC ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@contactNo", student.ContactNo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Update student record
        public bool UpdateStudent(Student student)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Registration SET firstName = @firstName, lastName = @lastName, 
                                   dateOfBirth = @dateOfBirth, gender = @gender, address = @address, 
                                   email = @email, mobilePhone = @mobilePhone, homePhone = @homePhone, 
                                   parentName = @parentName, nic = @nic, contactNo = @contactNo 
                                   WHERE regNo = @regNo";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", student.RegNo);
                        cmd.Parameters.AddWithValue("@firstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", student.LastName);
                        cmd.Parameters.AddWithValue("@dateOfBirth", student.DateOfBirth);
                        cmd.Parameters.AddWithValue("@gender", student.Gender);
                        cmd.Parameters.AddWithValue("@address", student.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", student.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@mobilePhone", student.MobilePhone);
                        cmd.Parameters.AddWithValue("@homePhone", student.HomePhone);
                        cmd.Parameters.AddWithValue("@parentName", student.ParentName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@nic", student.NIC ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@contactNo", student.ContactNo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Delete student record
        public bool DeleteStudent(int regNo)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", regNo);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Get student by registration number
        public Student? GetStudentByRegNo(int regNo)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", regNo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Student
                                {
                                    RegNo = (int)reader["regNo"],
                                    FirstName = reader["firstName"].ToString() ?? "",
                                    LastName = reader["lastName"].ToString() ?? "",
                                    DateOfBirth = (DateTime)reader["dateOfBirth"],
                                    Gender = reader["gender"].ToString() ?? "",
                                    Address = reader["address"]?.ToString() ?? "",
                                    Email = reader["email"]?.ToString() ?? "",
                                    MobilePhone = reader["mobilePhone"] != DBNull.Value ? (int)reader["mobilePhone"] : 0,
                                    HomePhone = reader["homePhone"] != DBNull.Value ? (int)reader["homePhone"] : 0,
                                    ParentName = reader["parentName"]?.ToString() ?? "",
                                    NIC = reader["nic"]?.ToString() ?? "",
                                    ContactNo = reader["contactNo"] != DBNull.Value ? (int)reader["contactNo"] : 0
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        // Get all registration numbers
        public List<int> GetAllRegNumbers()
        {
            List<int> regNumbers = new List<int>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT regNo FROM Registration ORDER BY regNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                regNumbers.Add((int)reader["regNo"]);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return regNumbers;
        }
    }
}
