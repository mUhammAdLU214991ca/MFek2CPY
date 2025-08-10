// 代码生成时间: 2025-08-10 11:22:27
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;

/// <summary>
/// A security audit logger for Unity applications.
/// </summary>
public class SecurityAuditLogger : MonoBehaviour
{
    private const string LogFilePath = "SecurityAudit.log";
    private Queue<string> logQueue = new Queue<string>();
    private bool isWritingToFile = false;

    /// <summary>
    /// Log a message to the security audit log.
    /// </summary>
    /// <param name="message">The message to be logged.</param>
    public void Log(string message)
    {
        try
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be null or empty.", nameof(message));

            logQueue.Enqueue(message);

            // Check if we can write to file immediately
            if (!isWritingToFile)
            {
                WriteToLog();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to log message: {ex.Message}");
        }
    }

    /// <summary>
    /// Writes the queued log messages to the log file.
    /// </summary>
    private void WriteToLog()
    {
        isWritingToFile = true;
        while (logQueue.Count > 0)
        {
            string logMessage = logQueue.Dequeue();
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true, Encoding.UTF8))
                {
                    writer.WriteLine($"[{DateTime.Now}] {logMessage}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error writing to log file: {ex.Message}");
            }
        }
        isWritingToFile = false;
    }

    /// <summary>
    /// Ensures that all the queued log messages are written to the log file on application quit.
    /// </summary>
    private void OnApplicationQuit()
    {
        WriteToLog();
    }
}
