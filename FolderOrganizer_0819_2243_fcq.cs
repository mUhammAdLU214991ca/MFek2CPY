// 代码生成时间: 2025-08-19 22:43:32
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FolderOrganizer is a utility class that helps in organizing file structures.
/// </summary>
public class FolderOrganizer
{
    private readonly string _rootFolderPath;

    /// <summary>
    /// Initializes a new instance of the FolderOrganizer class.
    /// </summary>
    /// <param name="rootFolderPath">The root folder path to be organized.</param>
    public FolderOrganizer(string rootFolderPath)
    {
        if (string.IsNullOrEmpty(rootFolderPath))
            throw new ArgumentException("Root folder path cannot be null or empty.", nameof(rootFolderPath));

        _rootFolderPath = rootFolderPath;
    }

    /// <summary>
    /// Organizes the files within the root folder path.
    /// </summary>
    public void OrganizeFiles()
    {
        try
        {
            // Ensure the root folder exists
            if (!Directory.Exists(_rootFolderPath))
                throw new DirectoryNotFoundException("Root folder does not exist.");

            // Get all files and directories within the root folder
            var files = Directory.GetFiles(_rootFolderPath);
            var directories = Directory.GetDirectories(_rootFolderPath);

            // Organize files into directories
            foreach (var file in files)
            {
                OrganizeFile(file);
            }

            // Organize directories
            foreach (var directory in directories)
            {
                OrganizeDirectory(directory);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error organizing files: {ex.Message}");
        }
    }

    /// <summary>
    /// Organizes a single file by moving it to an appropriate directory based on its extension.
    /// </summary>
    /// <param name="filePath">The path to the file to be organized.</param>
    private void OrganizeFile(string filePath)
    {
        var fileExtension = Path.GetExtension(filePath).ToLower();
        var directoryName = $"Files\{fileExtension}";
        var targetDirectory = Path.Combine(_rootFolderPath, directoryName);

        // Create the directory if it does not exist
        if (!Directory.Exists(targetDirectory))
            Directory.CreateDirectory(targetDirectory);

        // Move the file to the target directory
        File.Move(filePath, Path.Combine(targetDirectory, Path.GetFileName(filePath)));
    }

    /// <summary>
    /// Organizes the files within a given directory.
    /// </summary>
    /// <param name="directoryPath">The path to the directory to be organized.</param>
    private void OrganizeDirectory(string directoryPath)
    {
        // Recursively organize files within the directory
        foreach (var file in Directory.GetFiles(directoryPath))
        {
            OrganizeFile(file);
        }
    }
}
