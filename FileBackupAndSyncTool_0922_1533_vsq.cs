// 代码生成时间: 2025-09-22 15:33:30
// FileBackupAndSyncTool.cs
// This class provides functionality to backup and synchronize files.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FileBackupAndSync
{
    public class FileBackupAndSyncTool
    {
        // The source directory path
        private string sourcePath;
        // The destination directory path for backup and sync
        private string destinationPath;

        public FileBackupAndSyncTool(string source, string destination)
        {
            sourcePath = source;
            destinationPath = destination;
        }

        // Method to perform file backup
        public void BackupFiles()
        {
            try
            {
                DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
                DirectoryInfo destinationDir = new DirectoryInfo(destinationPath);

                // Check if source directory exists
                if (!sourceDir.Exists)
                {
                    Debug.LogError("Source directory does not exist: " + sourcePath);
                    return;
                }

                // Create destination directory if it does not exist
                if (!destinationDir.Exists)
                {
                    destinationDir.Create();
                }

                // Copy all files from source to destination
                foreach (FileInfo file in sourceDir.GetFiles())
                {
                    File.Copy(file.FullName, Path.Combine(destinationPath, file.Name), true);
                }

                Debug.Log("File backup completed successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError("Error during file backup: " + ex.Message);
            }
        }

        // Method to synchronize files between source and destination
        public void SyncFiles()
        {
            try
            {
                DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
                DirectoryInfo destinationDir = new DirectoryInfo(destinationPath);

                // Check if source directory exists
                if (!sourceDir.Exists)
                {
                    Debug.LogError("Source directory does not exist: " + sourcePath);
                    return;
                }

                // Check if destination directory exists
                if (!destinationDir.Exists)
                {
                    Debug.LogError("Destination directory does not exist: " + destinationPath);
                    return;
                }

                // Get all files in both directories
                var sourceFiles = sourceDir.GetFiles().Select(f => f.Name).ToList();
                var destinationFiles = destinationDir.GetFiles().Select(f => f.Name).ToList();

                // Find files that need to be copied or deleted
                foreach (var file in sourceFiles)
                {
                    if (!destinationFiles.Contains(file))
                    {
                        File.Copy(Path.Combine(sourcePath, file), Path.Combine(destinationPath, file), true);
                    }
                }

                foreach (var file in destinationFiles)
                {
                    if (!sourceFiles.Contains(file))
                    {
                        File.Delete(Path.Combine(destinationPath, file));
                    }
                }

                Debug.Log("File synchronization completed successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError("Error during file synchronization: " + ex.Message);
            }
        }
    }
}
