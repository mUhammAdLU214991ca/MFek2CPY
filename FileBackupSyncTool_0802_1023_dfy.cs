// 代码生成时间: 2025-08-02 10:23:04
// C# Script for Unity Framework
// This class is a basic implementation of a file backup and sync tool.

using System;
using System.IO;

namespace FileBackupSyncTool
{
    public class FileBackupSyncTool
    {
        // Path to the source directory
        private readonly string sourceDirectory;
        // Path to the backup directory
        private readonly string backupDirectory;

        public FileBackupSyncTool(string sourcePath, string backupPath)
        {
            sourceDirectory = sourcePath;
            backupDirectory = backupPath;
        }

        // Method to synchronize files from source to backup directory
        public void SyncFiles()
        {
            try
            {
                // Check if directories exist
                if (!Directory.Exists(sourceDirectory))
                {
                    Debug.LogError($"Source directory does not exist: {sourceDirectory}");
                    return;
                }

                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                // Get all files in the source directory
                var sourceFiles = Directory.GetFiles(sourceDirectory);

                foreach (var file in sourceFiles)
                {
                    var fileName = Path.GetFileName(file);
                    var backupFilePath = Path.Combine(backupDirectory, fileName);

                    // Check if the file already exists in the backup directory
                    if (File.Exists(backupFilePath))
                    {
                        // Overwrite the file if it's different or if force overwrite is enabled
                        if (File.ReadAllText(file) != File.ReadAllText(backupFilePath))
                        {
                            File.Copy(file, backupFilePath, true);
                            Debug.Log($"Updated file in backup directory: {backupFilePath}");
                        }
                    }
                    else
                    {
                        // Copy the file to the backup directory
                        File.Copy(file, backupFilePath);
                        Debug.Log($"Backup file created: {backupFilePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while syncing files: {ex.Message}");
            }
        }

        // Method to restore files from backup to source directory
        public void RestoreFiles()
        {
            try
            {
                // Check if directories exist
                if (!Directory.Exists(backupDirectory))
                {
                    Debug.LogError($"Backup directory does not exist: {backupDirectory}");
                    return;
                }

                if (!Directory.Exists(sourceDirectory))
                {
                    Directory.CreateDirectory(sourceDirectory);
                }

                // Get all files in the backup directory
                var backupFiles = Directory.GetFiles(backupDirectory);

                foreach (var file in backupFiles)
                {
                    var fileName = Path.GetFileName(file);
                    var sourceFilePath = Path.Combine(sourceDirectory, fileName);

                    // Check if the file already exists in the source directory
                    if (File.Exists(sourceFilePath))
                    {
                        // Overwrite the file if it's different or if force overwrite is enabled
                        if (File.ReadAllText(file) != File.ReadAllText(sourceFilePath))
                        {
                            File.Copy(file, sourceFilePath, true);
                            Debug.Log($"Updated file in source directory: {sourceFilePath}");
                        }
                    }
                    else
                    {
                        // Copy the file to the source directory
                        File.Copy(file, sourceFilePath);
                        Debug.Log($"Restored file to source directory: {sourceFilePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while restoring files: {ex.Message}");
            }
        }
    }
}
