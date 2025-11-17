using System.Data.SqlClient;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    /// <summary>
    /// Database repository using ConnectionFactory pattern
    /// Version 6 (Soft Pastel) characteristic
    /// </summary>
    public class DatabaseRepository
    {
        private readonly ConnectionFactory connection_factory;

        public DatabaseRepository()
        {
            connection_factory = ConnectionFactory.GetInstance();
        }

        public bool AuthenticateUser(string user_name, string pass_word)
        {
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string query_text = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                    using (SqlCommand command = new SqlCommand(query_text, connection))
                    {
                        command.Parameters.AddWithValue("@username", user_name);
                        command.Parameters.AddWithValue("@password", pass_word);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Check if registration number exists
        public bool CheckIfRegistrationExists(int registration_number)
        {
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string query_text = "SELECT COUNT(*) FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand command = new SqlCommand(query_text, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", registration_number);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewStudent(Student student_data)
        {
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string insert_query = @"INSERT INTO Registration 
                        (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, parentName, nic, contactNo) 
                        VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @homePhone, @parentName, @nic, @contactNo)";

                    using (SqlCommand command = new SqlCommand(insert_query, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", student_data.RegNo);
                        command.Parameters.AddWithValue("@firstName", student_data.FirstName);
                        command.Parameters.AddWithValue("@lastName", student_data.LastName);
                        command.Parameters.AddWithValue("@dateOfBirth", student_data.DateOfBirth);
                        command.Parameters.AddWithValue("@gender", student_data.Gender);
                        command.Parameters.AddWithValue("@address", student_data.Address);
                        command.Parameters.AddWithValue("@email", student_data.Email);
                        command.Parameters.AddWithValue("@mobilePhone", student_data.MobilePhone);
                        command.Parameters.AddWithValue("@homePhone", student_data.HomePhone);
                        command.Parameters.AddWithValue("@parentName", student_data.ParentName);
                        command.Parameters.AddWithValue("@nic", student_data.NIC);
                        command.Parameters.AddWithValue("@contactNo", student_data.ContactNo);

                        int rows_affected = command.ExecuteNonQuery();
                        return rows_affected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ModifyStudentRecord(Student student_data)
        {
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string update_query = @"UPDATE Registration SET 
                        firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, 
                        gender = @gender, address = @address, email = @email, 
                        mobilePhone = @mobilePhone, homePhone = @homePhone, 
                        parentName = @parentName, nic = @nic, contactNo = @contactNo 
                        WHERE regNo = @regNo";

                    using (SqlCommand command = new SqlCommand(update_query, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", student_data.RegNo);
                        command.Parameters.AddWithValue("@firstName", student_data.FirstName);
                        command.Parameters.AddWithValue("@lastName", student_data.LastName);
                        command.Parameters.AddWithValue("@dateOfBirth", student_data.DateOfBirth);
                        command.Parameters.AddWithValue("@gender", student_data.Gender);
                        command.Parameters.AddWithValue("@address", student_data.Address);
                        command.Parameters.AddWithValue("@email", student_data.Email);
                        command.Parameters.AddWithValue("@mobilePhone", student_data.MobilePhone);
                        command.Parameters.AddWithValue("@homePhone", student_data.HomePhone);
                        command.Parameters.AddWithValue("@parentName", student_data.ParentName);
                        command.Parameters.AddWithValue("@nic", student_data.NIC);
                        command.Parameters.AddWithValue("@contactNo", student_data.ContactNo);

                        int rows_affected = command.ExecuteNonQuery();
                        return rows_affected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Remove student record
        public bool RemoveStudent(int registration_number)
        {
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string delete_query = "DELETE FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand command = new SqlCommand(delete_query, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", registration_number);
                        int rows_affected = command.ExecuteNonQuery();
                        return rows_affected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Retrieve student record by registration number
        public Student RetrieveStudentByRegNo(int registration_number)
        {
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string select_query = "SELECT * FROM Registration WHERE regNo = @regNo";
                    using (SqlCommand command = new SqlCommand(select_query, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", registration_number);
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
                                    MobilePhone = Convert.ToInt32(reader["mobilePhone"]),
                                    HomePhone = Convert.ToInt32(reader["homePhone"]),
                                    ParentName = reader["parentName"].ToString() ?? string.Empty,
                                    NIC = reader["nic"].ToString() ?? string.Empty,
                                    ContactNo = Convert.ToInt32(reader["contactNo"])
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return null!;
        }

        public List<int> GetAllRegistrationNumbers()
        {
            List<int> registration_list = new List<int>();
            try
            {
                using (SqlConnection connection = connection_factory.CreateAndOpenConnection())
                {
                    string select_query = "SELECT regNo FROM Registration ORDER BY regNo";
                    using (SqlCommand command = new SqlCommand(select_query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registration_list.Add(Convert.ToInt32(reader["regNo"]));
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return registration_list;
        }
    }
}
