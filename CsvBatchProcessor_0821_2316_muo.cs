// 代码生成时间: 2025-08-21 23:16:43
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class CsvBatchProcessor
{
    // Path to the directory containing CSV files.
    private string directoryPath;

    public CsvBatchProcessor(string directory)
    {
        if (string.IsNullOrEmpty(directory))
        {
            throw new ArgumentException("Directory path cannot be null or empty.");
        }

        this.directoryPath = directory;
    }

    // Process all CSV files in the specified directory.
    public void ProcessFiles()
    {
        try
        {
            var csvFiles = Directory.GetFiles(directoryPath, "*.csv");
            foreach (var file in csvFiles)
            {
                ProcessFile(file);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while processing CSV files: {ex.Message}");
        }
    }

    // Process a single CSV file.
    private void ProcessFile(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Assuming a CSV with a header and comma separation.
                    var values = line.Split(',');
                    ProcessLine(values);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while processing file {filePath}: {ex.Message}");
        }
    }

    // Process a single line from a CSV file.
    private void ProcessLine(string[] values)
    {
        // This method should be overridden by subclasses to implement specific processing logic.
        throw new NotImplementedException("ProcessLine must be implemented by subclass.");
    }
}
