using System.Data.SqlClient;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    /// <summary>
    /// Database helper using singleton connection - Version 3 style
    /// </summary>
    public class DBHelper
    {
        // Use singleton for connection
        public bool ValidateUser(string strUsername, string strPassword)
        {
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", strUsername);
                        cmd.Parameters.AddWithValue("@password", strPassword);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public List<int> GetAllRegNumbers()
        {
            List<int> regNumbers = new List<int>();
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT regNo FROM Registration ORDER BY regNo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        regNumbers.Add(reader.GetInt32(0));
                    }
                }
            }
            return regNumbers;
        }

        public Student? GetStudentByRegNo(int intRegNo)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Registration WHERE regNo = @regNo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@regNo", intRegNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                RegNo = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Gender = reader.GetString(4),
                                Address = reader.GetString(5),
                                Email = reader.GetString(6),
                                MobilePhone = reader.GetInt32(7),
                                HomePhone = reader.GetInt32(8),
                                ParentName = reader.GetString(9),
                                NIC = reader.GetString(10),
                                ContactNo = reader.GetInt32(11)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool RegNoExists(int intRegNo)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Registration WHERE regNo = @regNo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@regNo", intRegNo);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public bool InsertStudent(Student student)
        {
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Registration (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, parentName, nic, contactNo)
                                    VALUES (@regNo, @firstName, @lastName, @dob, @gender, @address, @email, @mobile, @home, @parent, @nic, @contact)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", student.RegNo);
                        cmd.Parameters.AddWithValue("@firstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", student.LastName);
                        cmd.Parameters.AddWithValue("@dob", student.DateOfBirth);
                        cmd.Parameters.AddWithValue("@gender", student.Gender);
                        cmd.Parameters.AddWithValue("@address", student.Address);
                        cmd.Parameters.AddWithValue("@email", student.Email);
                        cmd.Parameters.AddWithValue("@mobile", student.MobilePhone);
                        cmd.Parameters.AddWithValue("@home", student.HomePhone);
                        cmd.Parameters.AddWithValue("@parent", student.ParentName);
                        cmd.Parameters.AddWithValue("@nic", student.NIC);
                        cmd.Parameters.AddWithValue("@contact", student.ContactNo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Registration SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dob,
                                    gender = @gender, address = @address, email = @email, mobilePhone = @mobile,
                                    homePhone = @home, parentName = @parent, nic = @nic, contactNo = @contact
                                    WHERE regNo = @regNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", student.RegNo);
                        cmd.Parameters.AddWithValue("@firstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", student.LastName);
                        cmd.Parameters.AddWithValue("@dob", student.DateOfBirth);
                        cmd.Parameters.AddWithValue("@gender", student.Gender);
                        cmd.Parameters.AddWithValue("@address", student.Address);
                        cmd.Parameters.AddWithValue("@email", student.Email);
                        cmd.Parameters.AddWithValue("@mobile", student.MobilePhone);
                        cmd.Parameters.AddWithValue("@home", student.HomePhone);
                        cmd.Parameters.AddWithValue("@parent", student.ParentName);
                        cmd.Parameters.AddWithValue("@nic", student.NIC);
                        cmd.Parameters.AddWithValue("@contact", student.ContactNo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteStudent(int intRegNo)
        {
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@regNo", intRegNo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
