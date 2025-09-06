// 代码生成时间: 2025-09-06 14:24:09
using System;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// A utility class for renaming files in batch within Unity.
/// </summary>
public class BatchFileRenamer
{
    /// <summary>
    /// Renames all files in a directory with a specified pattern.
# 改进用户体验
    /// </summary>
# 改进用户体验
    /// <param name="directoryPath">Path to the directory containing files to rename.</param>
    /// <param name="searchPattern">Pattern to search for in filenames.</param>
    /// <param name="newName">New name for the files.</param>
    public static void RenameFilesInDirectory(string directoryPath, string searchPattern, string newName)
    {
# 添加错误处理
        try
        {
# 添加错误处理
            // Get all files in the directory that match the search pattern.
            var files = Directory.GetFiles(directoryPath, searchPattern).ToList();

            // Rename each file that matches the search pattern.
            for (int i = 0; i < files.Count; i++)
            {
                string oldFilePath = files[i];
                string newFilePath = Path.Combine(
                    Path.GetDirectoryName(oldFilePath),
                    newName + Path.GetExtension(oldFilePath)
                );
# FIXME: 处理边界情况

                // Check if the file already exists with the new name to avoid overwriting.
                if (!File.Exists(newFilePath))
                {
                    // Rename the file.
                    File.Move(oldFilePath, newFilePath);
                    Debug.Log($"Renamed '{oldFilePath}' to '{newFilePath}'.");
                }
                else
                {
                    Debug.LogWarning($"File '{newFilePath}' already exists. Skipping rename for '{oldFilePath}'.");
                }
            }
        }
# 添加错误处理
        catch (Exception ex)
        {
            Debug.LogError($"Error renaming files: {ex.Message}");
# FIXME: 处理边界情况
        }
# 添加错误处理
    }
}

/// <summary>
/// Example usage of BatchFileRenamer.
/// </summary>
public class FileRenamerExample
{
    /// <summary>
    /// Example method to demonstrate the usage of BatchFileRenamer.
    /// </summary>
    public void RenameFilesExample()
    {
        string directoryPath = "C:/ExampleDirectory"; // Replace with your directory path.
        string searchPattern = "*.txt"; // Replace with your search pattern.
# NOTE: 重要实现细节
        string newName = "renamedFile"; // Replace with your new file name.

        BatchFileRenamer.RenameFilesInDirectory(directoryPath, searchPattern, newName);
    }
}