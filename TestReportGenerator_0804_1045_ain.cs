// 代码生成时间: 2025-08-04 10:45:06
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Test report generator class.
/// </summary>
public class TestReportGenerator
{
    /// <summary>
    /// Generates a test report as a text file.
    /// </summary>
    /// <param name="testResults">List of test results to include in the report.</param>
    /// <param name="reportFilePath">Path to save the test report.</param>
    /// <returns>True if the report was generated successfully, otherwise false.</returns>
    public bool GenerateReport(List<string> testResults, string reportFilePath)
    {
        try
        {
            // Check if the report file path is not null or empty
            if (string.IsNullOrEmpty(reportFilePath))
            {
                Debug.LogError("Report file path cannot be null or empty.");
                return false;
            }

            // Check if there are any test results to write
            if (testResults == null || testResults.Count == 0)
            {
                Debug.LogError("No test results to generate a report.");
                return false;
            }

            // Create the report content
            string reportContent = "Test Report

";
            foreach (var result in testResults)
            {
                reportContent += result + "
";
            }

            // Write the report to the file
            File.WriteAllText(reportFilePath, reportContent);

            Debug.Log($"Test report generated successfully at: {reportFilePath}");

            return true;
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur during report generation
            Debug.LogError($"Error generating test report: {ex.Message}");
            return false;
        }
    }
}
