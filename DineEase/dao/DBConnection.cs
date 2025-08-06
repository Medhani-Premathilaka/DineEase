using System;
using System.Data.SqlClient;
using System.IO;
namespace DineEase.dao
{
    public class DBConnection
    {
        private static readonly object padlock = new object();
        private readonly string connectionString;
        private static DBConnection instance;

        private DBConnection()
        {
            // Load environment variables from .env file
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.env");
            envPath = Path.GetFullPath(envPath);

            // Load environment variables from .env file
            DotNetEnv.Env.Load(envPath);
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            // Check if the connection string is loaded correctly
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                // You can log, throw, or show a message here for debugging
                throw new InvalidOperationException(
                    "DB_CONNECTION_STRING environment variable is missing or empty. " +
                    "Check your .env file and ensure the variable is set correctly.");
            }
        }

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