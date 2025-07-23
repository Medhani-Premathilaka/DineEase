using System.Data.SqlClient;

namespace DineEase.dao
{
    public class DBConnection
    {
        private static DBConnection instance;
        private static readonly object padlock = new object();

        private readonly string connectionString = @"Server=dineease.chc86qwacnkf.eu-north-1.rds.amazonaws.com;Database=DineEase;User Id=admin;Password=DineEase;";

        private DBConnection() { }

        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBConnection();
                    }
                }
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}