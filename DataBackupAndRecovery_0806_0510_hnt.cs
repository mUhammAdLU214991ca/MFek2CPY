// 代码生成时间: 2025-08-06 05:10:39
using System;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// Provides functionality for data backup and recovery.
/// </summary>
public class DataBackupAndRecovery : MonoBehaviour
{
    /// <summary>
    /// The directory path for the backup folder.
    /// </summary>
    private const string BackupDirectory = "Backup/";

    /// <summary>
    /// The path to the file to be backed up.
    /// </summary>
    private const string DataFilePath = "Data/dataFile.txt";

    /// <summary>
    /// The timestamp format for backup file names.
    /// </summary>
    private const string TimestampFormat = "yyyyMMddHHmmss";

    /// <summary>
    /// Initializes the backup directory if it does not exist.
    /// </summary>
    private void InitializeBackupDirectory()
    {
        if (!Directory.Exists(BackupDirectory))
        {
            Directory.CreateDirectory(BackupDirectory);
        }
    }

    /// <summary>
    /// Backs up the data file to the backup directory.
    /// </summary>
    /// <returns>The path to the backup file.</returns>
    public string BackupData()
    {
        InitializeBackupDirectory();
        string timestamp = DateTime.Now.ToString(TimestampFormat);
        string backupFilePath = Path.Combine(BackupDirectory, $"backup_{timestamp}.txt");

        try
        {
            File.Copy(DataFilePath, backupFilePath);
            return backupFilePath;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to backup data: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Recovers the data from the latest backup file.
    /// </summary>
    /// <param name="backupFilePath">The path to the backup file to recover from.</param>
    public void RecoverData(string backupFilePath)
    {
        try
        {
            if (File.Exists(backupFilePath))
            {
                File.Copy(backupFilePath, DataFilePath, true);
            }
            else
            {
                Debug.LogError($"Backup file not found: {backupFilePath}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to recover data: {ex.Message}");
        }
    }

    /// <summary>
    /// Finds the latest backup file in the backup directory.
    /// </summary>
    /// <returns>The path to the latest backup file.</returns>
    public string FindLatestBackup()
    {
        string[] backupFiles = Directory.GetFiles(BackupDirectory);
        if (backupFiles.Length == 0)
        {
            Debug.LogWarning("There are no backup files available.");
            return null;
        }

        string latestBackup = null;
        DateTime latestTimestamp = DateTime.MinValue;

        foreach (string file in backupFiles)
        {
            string fileName = Path.GetFileName(file);
            if (DateTime.TryParseExact(fileName.Substring(fileName.IndexOf("_") + 1), TimestampFormat, null, System.Globalization.DateTimeStyles.None, out DateTime timestamp))
            {
                if (timestamp > latestTimestamp)
                {
                    latestTimestamp = timestamp;
                    latestBackup = file;
                }
            }
        }

        return latestBackup;
    }
}
