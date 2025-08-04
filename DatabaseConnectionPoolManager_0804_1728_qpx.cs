// 代码生成时间: 2025-08-04 17:28:51
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using UnityEngine;

/// <summary>
/// Database connection pool manager class.
/// </summary>
public class DatabaseConnectionPoolManager
{
    private readonly object _syncLock = new object();
# NOTE: 重要实现细节
    private readonly Queue<DbConnection> _availableConnections;
    private readonly Queue<DbConnection> _checkedOutConnections;
    private readonly int _maxPoolSize;
    private readonly string _connectionString;
# NOTE: 重要实现细节
    private readonly Type _connectionType;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConnectionPoolManager"/> class.
# 添加错误处理
    /// </summary>
    /// <param name="connectionString">The database connection string.</param>
    /// <param name="maxPoolSize">The maximum number of connections in the pool.</param>
    public DatabaseConnectionPoolManager(string connectionString, int maxPoolSize)
    {
        _connectionString = connectionString;
        _maxPoolSize = maxPoolSize;
        _availableConnections = new Queue<DbConnection>();
        _checkedOutConnections = new Queue<DbConnection>();
# 扩展功能模块

        // Determine the connection type based on the connection string
# NOTE: 重要实现细节
        if (connectionString.Contains("Server") && connectionString.Contains("Trusted_Connection"))
        {
            // SQL Server
            _connectionType = typeof(System.Data.SqlClient.SqlConnection);
        }
        else
# 增强安全性
        {
            // Assume a generic DbConnection
# FIXME: 处理边界情况
            _connectionType = typeof(DbConnection);
        }
    }
# TODO: 优化性能

    /// <summary>
    /// Gets a connection from the pool or creates a new one if necessary.
    /// </summary>
    /// <returns>A database connection from the pool.</returns>
# 扩展功能模块
    public DbConnection GetConnection()
    {
# 添加错误处理
        lock (_syncLock)
        {
            if (_availableConnections.Count > 0)
            {
                return _availableConnections.Dequeue();
            }
            else if (_checkedOutConnections.Count < _maxPoolSize)
# 优化算法效率
            {
                return CreateConnection();
            }
            else
            {
                throw new InvalidOperationException("Connection pool has reached its maximum size.");
            }
        }
    }

    /// <summary>
    /// Returns a connection to the pool.
    /// </summary>
    /// <param name="connection">The connection to return.</param>
    public void ReturnConnection(DbConnection connection)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
# 扩展功能模块
        }

        lock (_syncLock)
        {
            _checkedOutConnections.Enqueue(connection);
# NOTE: 重要实现细节
            _availableConnections.Enqueue(connection);
        }
    }

    /// <summary>
    /// Creates a new database connection.
    /// </summary>
    /// <returns>A new database connection.</returns>
    private DbConnection CreateConnection()
    {
        DbConnection connection = (DbConnection)Activator.CreateInstance(_connectionType);
        connection.ConnectionString = _connectionString;
        connection.Open();
        _checkedOutConnections.Enqueue(connection);
        return connection;
    }

    /// <summary>
# TODO: 优化性能
    /// Closes all connections in the pool.
    /// </summary>
    public void CloseAllConnections()
# 优化算法效率
    {
        lock (_syncLock)
        {
# 增强安全性
            foreach (var connection in _availableConnections)
            {
                connection.Close();
            }
            _availableConnections.Clear();

            foreach (var connection in _checkedOutConnections)
# NOTE: 重要实现细节
            {
                connection.Close();
            }
            _checkedOutConnections.Clear();
        }
    }
}
