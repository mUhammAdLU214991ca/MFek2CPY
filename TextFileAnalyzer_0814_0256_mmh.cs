// 代码生成时间: 2025-08-14 02:56:20
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// A utility class for analyzing text file content.
/// </summary>
public class TextFileAnalyzer
{
    /// <summary>
    /// Analyzes the content of a text file and returns basic statistics.
    /// </summary>
    /// <param name="filePath">The path to the text file.</param>
    /// <returns>A dictionary containing file statistics.</returns>
    public Dictionary<string, object> AnalyzeTextFile(string filePath)
    {
        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Debug.LogError("File does not exist: " + filePath);
            return null;
        }

        try
        {
            // Read all text from the file
            string content = File.ReadAllText(filePath);

            // Perform analysis
            return PerformAnalysis(content);
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur during file reading or analysis
            Debug.LogError("Error analyzing file: " + ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Analyzes the text content and calculates statistics.
    /// </summary>
    /// <param name="content">The text content to analyze.</param>
    /// <returns>A dictionary containing file statistics.</returns>
    private Dictionary<string, object> PerformAnalysis(string content)
    {
        var statistics = new Dictionary<string, object>();

        // Calculate word count
        var wordMatches = Regex.Matches(content, @"\b\w+\b");
        statistics["WordCount"] = wordMatches.Count;

        // Calculate sentence count (assuming sentences end with . or ? or !)
        var sentenceMatches = Regex.Matches(content, @"[.?!]+" + @