// 代码生成时间: 2025-09-14 07:41:35
// <summary>
// A utility class that helps in renaming files in a directory.
// </summary>
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class BulkFileRenamer
{
    // <summary>
    // Renames files in the specified directory according to the given pattern.
    // </summary>
    // <param name="directory">Directory path where files are located.</param>
    // <param name="pattern">Pattern to be applied to file names.</param>
    public void RenameFilesInDirectory(string directory, string pattern)
    {
        try
        {
            // Get all files in the directory.
            string[] files = Directory.GetFiles(directory);
            int counter = 1; // Counter to ensure unique file names.

            // Loop through each file and rename it.
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                // Apply the pattern to the file name.
                string newName = ApplyPattern(fileInfo.Name, pattern, counter);
                // Rename the file.
                File.Move(file, Path.Combine(directory, newName));

                // Increment the counter for the next file.
                counter++;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error renaming files: " + ex.Message);
        }
    }

    // <summary>
    // Applies the renaming pattern to the file name.
    // </summary>
    // <param name="currentName">Current file name.</param>
    // <param name="pattern">Pattern to apply.</param>
    // <param name="counter">Counter to ensure unique file names.</param>
    // <returns>The new file name.</returns>
    private string ApplyPattern(string currentName, string pattern, int counter)
    {
        // Replace the "{counter}" in the pattern with the current counter value.
        string newName = Regex.Replace(pattern, @"{counter}", counter.ToString());
        // Ensure the file extension is preserved.
        int extensionIndex = currentName.LastIndexOf('.');
        if (extensionIndex > 0)
        {
            string extension = currentName.Substring(extensionIndex);
            newName = Path.ChangeExtension(newName, extension);
        }
        return newName;
    }

    // <summary>
    // Main method for testing the BulkFileRenamer class.
    // </summary>
    public static void Main(string[] args)
    {
        BulkFileRenamer renamer = new BulkFileRenamer();
        string directoryPath = @"C:\path	o\files"; // Change this to your directory.
        string renamePattern = @"NewFileName_{counter}.txt"; // Change this to your desired pattern.
        renamer.RenameFilesInDirectory(directoryPath, renamePattern);
    }
}
