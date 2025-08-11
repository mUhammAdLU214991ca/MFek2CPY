// 代码生成时间: 2025-08-11 23:26:15
using System;
using System.IO;

/// <summary>
/// Provides functionality for file backup and synchronization.
/// </summary>
public class FileBackupUtility
{
    private string sourcePath;
    private string backupPath;

    /// <summary>
    /// Initializes a new instance of the FileBackupUtility class.
    /// </summary>
    /// <param name="sourcePath">The path to the directory to be backed up.</param>
    /// <param name="backupPath">The path to the backup directory.</param>
    public FileBackupUtility(string sourcePath, string backupPath)
    {
        this.sourcePath = sourcePath;
        this.backupPath = backupPath;
    }

    /// <summary>
    /// Performs the backup of the source files to the backup directory.
    /// </summary>
    public void BackupFiles()
    {
        try
        {
            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourcePath}");
            }

            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

            var files = Directory.GetFiles(sourcePath);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var backupFile = Path.Combine(backupPath, fileInfo.Name);
                File.Copy(file, backupFile, true); // overwrite if file exists
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during backup: {ex.Message}");
        }
    }

    /// <summary>
    /// Synchronizes the source directory with the backup directory.
    /// </summary>
    public void SynchronizeDirectories()
    {
        try
        {
            if (!Directory.Exists(sourcePath) || !Directory.Exists(backupPath))
            {
                throw new DirectoryNotFoundException($"Source or backup directory not found. Source: {sourcePath}, Backup: {backupPath}");
            }

            var sourceFiles = Directory.GetFiles(sourcePath);
            var backupFiles = Directory.GetFiles(backupPath);

            foreach (var sourceFile in sourceFiles)
            {
                var fileInfo = new FileInfo(sourceFile);
                var backupFile = Path.Combine(backupPath, fileInfo.Name);
                if (!File.Exists(backupFile))
                {
                    File.Copy(sourceFile, backupFile, true); // overwrite if file exists
                }
                else
                {
                    var backupFileInfo = new FileInfo(backupFile);
                    if (fileInfo.LastWriteTime != backupFileInfo.LastWriteTime)
                    {
                        File.Copy(sourceFile, backupFile, true); // overwrite if file is newer
                    }
                }
            }

            // Remove files from backup that no longer exist in source
            foreach (var backupFile in backupFiles)
            {
                var fileInfo = new FileInfo(backupFile);
                var sourceFile = Path.Combine(sourcePath, fileInfo.Name);
                if (!File.Exists(sourceFile))
                {
                    File.Delete(backupFile);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during synchronization: {ex.Message}");
        }
    }
}
