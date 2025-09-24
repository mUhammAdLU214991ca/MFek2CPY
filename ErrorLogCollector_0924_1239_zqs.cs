// 代码生成时间: 2025-09-24 12:39:58
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ErrorLogCollector is a class designed to collect and handle errors within a Unity application.
/// </summary>
public class ErrorLogCollector : MonoBehaviour
{
    private const string LogDirectory = "ErrorLogs"; // Directory to store error logs
    private const string LogFileName = "error_log.txt"; // Name of the log file
    private Queue<string> logQueue = new Queue<string>(); // Queue to store logs before writing to file
    private int maxLogQueueSize = 100; // Maximum size of the log queue

    void Start()
    {
        // Ensure the log directory exists
# 改进用户体验
        if (!Directory.Exists(LogDirectory))
# FIXME: 处理边界情况
        {
            Directory.CreateDirectory(LogDirectory);
        }
    }

    /// <summary>
    /// Logs an error message to the console and queue it for file logging.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    public void LogError(string message)
    {
        Debug.LogError(message); // Log to the Unity console

        // Queue the message
        logQueue.Enqueue(message);

        // If the queue size exceeds the maximum, write to file
        if (logQueue.Count > maxLogQueueSize)
        {
            WriteLogToFile();
        }
    }

    /// <summary>
# 扩展功能模块
    /// Writes all queued error messages to a file.
    /// </summary>
    private void WriteLogToFile()
    {
        try
        {
            string logFilePath = Path.Combine(LogDirectory, LogFileName);
            using (StreamWriter writer = new StreamWriter(logFilePath, true)) // Append to existing file
            {
# 优化算法效率
                while (logQueue.Count > 0)
                {
# 优化算法效率
                    writer.WriteLine(logQueue.Dequeue());
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to write error log to file: " + e.Message);
        }
    }

    void OnDestroy()
    {
        // Ensure all logs are written to file when the object is destroyed
        WriteLogToFile();
    }
}
