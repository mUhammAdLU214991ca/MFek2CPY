// 代码生成时间: 2025-08-12 16:55:36
using System;
using System.IO;
using UnityEngine;

/// <summary>
/// ErrorLogCollector is responsible for collecting and managing error logs in Unity.
/// </summary>
# 优化算法效率
public class ErrorLogCollector : MonoBehaviour
{
    /// <summary>
    /// The path to the directory where error logs will be saved.
# 扩展功能模块
    /// </summary>
    private string logDirectory = "./Logs";

    /// <summary>
# 增强安全性
    /// The file name for the current error log.
# 添加错误处理
    /// </summary>
    private string logFileName = "error_log.txt";

    /// <summary>
# 增强安全性
    /// Start is called before the first frame update.
# 增强安全性
    /// Initializes the log directory if it doesn't exist.
    /// </summary>
    private void Start()
    {
# 扩展功能模块
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }
# TODO: 优化性能

    /// <summary>
    /// Logs an error message to the error log file.
    /// </summary>
    /// <param name="errorMessage">The error message to be logged.</param>
    public void LogError(string errorMessage)
    {
        try
        {
            string logFilePath = Path.Combine(logDirectory, logFileName);
            using (StreamWriter writer = new StreamWriter(logFilePath, true)) // Append to the file.
            {
                writer.WriteLine($"[{DateTime.Now}] {errorMessage}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to write error to log: {ex.Message}");
        }
    }
# 改进用户体验

    /// <summary>
    /// Clears the error log file.
    /// </summary>
    public void ClearLog()
    {
        try
        {
            string logFilePath = Path.Combine(logDirectory, logFileName);
            if (File.Exists(logFilePath))
            {
                File.WriteAllText(logFilePath, "");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to clear error log: {ex.Message}");
        }
    }
}
