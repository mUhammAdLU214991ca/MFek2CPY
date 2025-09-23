// 代码生成时间: 2025-09-24 00:37:30
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;

namespace DatabaseConnectionPoolManagement
{
    // Define a custom exception for database connection pool errors.
    public class DatabaseConnectionPoolException : Exception
    {
        public DatabaseConnectionPoolException(string message) : base(message)
        {
        }
    }

    public class DatabaseConnectionPoolManager
    {
        // Configuration for the connection pool.
        private string connectionString;
        private int maxConnections;
        private Queue<SqlConnection> availableConnections;
        private Queue<SqlConnection> inUseConnections;
        private readonly object poolLock = new object();

        public DatabaseConnectionPoolManager(string connectionString, int maxConnections)
        {
            this.connectionString = connectionString;
            this.maxConnections = maxConnections;
            this.availableConnections = new Queue<SqlConnection>();
            this.inUseConnections = new Queue<SqlConnection>();

            // Initialize the pool with the maximum number of connections.
            for (int i = 0; i < maxConnections; i++)
            {
                availableConnections.Enqueue(new SqlConnection(connectionString));
            }
        }

        // Get a connection from the pool.
        public SqlConnection GetConnection()
        {
            SqlConnection connection;
            lock (poolLock)
            {
                if (availableConnections.Count > 0)
                {
                    connection = availableConnections.Dequeue();
                    inUseConnections.Enqueue(connection);
                }
                else
                {
                    throw new DatabaseConnectionPoolException("No available connections in the pool.");
                }
            }
            return connection;
        }

        // Release a connection back to the pool.
        public void ReleaseConnection(SqlConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            lock (poolLock)
            {
                if (inUseConnections.Contains(connection))
                {
                    inUseConnections.Dequeue();
                    availableConnections.Enqueue(connection);
                }
                else
                {
                    throw new DatabaseConnectionPoolException("Attempted to release a connection not in use.");
                }
            }
        }

        // Dispose of a connection.
        public void DisposeConnection(SqlConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            lock (poolLock)
            {
                if (inUseConnections.Contains(connection))
                {
                    inUseConnections.Dequeue();
                    connection.Close();
                    connection.Dispose();
                }
                else
                {
                    throw new DatabaseConnectionPoolException("Attempted to dispose a connection not in use.");
                }
            }
        }
    }
}
