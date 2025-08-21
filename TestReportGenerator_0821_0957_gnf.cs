// 代码生成时间: 2025-08-21 09:57:11
// TestReportGenerator.cs
// This class is responsible for generating test reports in Unity using C#.

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestReportGenerator
{
    // The path where the report will be saved
    private string reportPath;

    public TestReportGenerator(string path)
    {
        // Constructor to initialize the report path
        reportPath = path;
    }

    // Method to generate the test report
    public void GenerateReport(List<string> testResults)
    {
        try
        {
            // Check if the list of test results is null or empty
            if (testResults == null || testResults.Count == 0)
            {
                Debug.LogError("No test results to generate report from.");
                return;
            }

            // Create the directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Open a stream writer to write the report to a file
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.WriteLine("Test Report");
                writer.WriteLine("------------");

                // Write each test result to the file
                foreach (var result in testResults)
                {
                    writer.WriteLine(result);
                }
            }

            Debug.Log($"Test report generated successfully at: {reportPath}");
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur during report generation
            Debug.LogError($"Error generating test report: {ex.Message}");
        }
    }
}
