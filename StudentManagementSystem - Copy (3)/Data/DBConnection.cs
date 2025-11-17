using System.Data.SqlClient;

namespace StudentManagementSystem.Data
{
    /// <summary>
    /// Singleton pattern for database connection
    /// Version 3: Minimal Clean style
    /// </summary>
    public class DBConnection
    {
        private static DBConnection? instance;
        private readonly string connStr;

        // Private constructor
        private DBConnection()
        {
            connStr = @"Server=DESKTOP-F2PGMGH\SQLEXPRESS03;Database=Student;Trusted_Connection=True;TrustServerCertificate=True";
        }

        // Singleton instance property
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection();
                }
                return instance;
            }
        }

        // Get connection method
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }

        // Get open connection
        public SqlConnection GetOpenConnection()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
