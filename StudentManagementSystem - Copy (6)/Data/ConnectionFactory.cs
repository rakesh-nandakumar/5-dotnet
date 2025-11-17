using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Data
{
    /// <summary>
    /// Connection Factory pattern for database connections
    /// Version 6 (Soft Pastel) characteristic - Factory pattern
    /// </summary>
    public class ConnectionFactory
    {
        private static ConnectionFactory? instance;
        private readonly string connection_string;

        private ConnectionFactory()
        {
            connection_string = @"Server=DESKTOP-F2PGMGH\SQLEXPRESS03;Database=Student;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public static ConnectionFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionFactory();
            }
            return instance;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connection_string);
        }

        public SqlConnection CreateAndOpenConnection()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            return connection;
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = CreateAndOpenConnection())
                {
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
