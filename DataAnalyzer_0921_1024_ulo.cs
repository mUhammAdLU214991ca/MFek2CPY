// 代码生成时间: 2025-09-21 10:24:56
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A data analyzer class to process and analyze statistical data.
/// </summary>
public class DataAnalyzer
{
    /// <summary>
    /// The method to analyze and process statistical data.
    /// </summary>
    /// <param name="data">A list of numerical data points.</param>
    /// <returns>Returns a dictionary containing the mean, median, and mode of the data.</returns>
    public Dictionary<string, double> AnalyzeData(List<double> data)
    {
        if (data == null || data.Count == 0)
        {
            // Handle the case where data is null or empty
            throw new ArgumentException("Data provided is null or empty.");
        }

        // Calculate the mean of the data
        double mean = 0;
        foreach (var number in data)
        {
            mean += number;
        }
        mean /= data.Count;

        // Calculate the median of the data
        double median = CalculateMedian(data);

        // Calculate the mode of the data
        double mode = CalculateMode(data);

        // Return the results in a dictionary
        return new Dictionary<string, double>
        {
            { "Mean", mean },
            { "Median", median },
            { "Mode", mode }
        };
    }

    /// <summary>
    /// Helper method to calculate the median of a list of numbers.
    /// </summary>
    /// <param name="data">A list of numerical data points.</param>
    /// <returns>Returns the median of the data.</returns>
    private double CalculateMedian(List<double> data)
    {
        int middleIndex = data.Count / 2;
        data.Sort();
        if (data.Count % 2 == 0)
        {
            // If the list has an even number of items, the median is the average of the two middle numbers
            return (data[middleIndex - 1] + data[middleIndex]) / 2;
        }
        else
        {
            // If the list has an odd number of items, the median is the middle item
            return data[middleIndex];
        }
    }

    /// <summary>
    /// Helper method to calculate the mode of a list of numbers.
    /// </summary>
    /// <param name="data">A list of numerical data points.</param>
    /// <returns>Returns the mode of the data.</returns>
    private double CalculateMode(List<double> data)
    {
        // This is a simplified version of mode calculation
        // It assumes that there is only one mode in the data set
        Dictionary<double, int> frequency = new Dictionary<double, int>();
        foreach (var number in data)
        {
            if (frequency.ContainsKey(number))
            {
                frequency[number]++;
            }
            else
            {
                frequency.Add(number, 1);
            }
        }

        // Find the number with the highest frequency, which is the mode
        double mode = data[0];
        int maxFrequency = frequency[mode];
        foreach (var kv in frequency)
        {
            if (kv.Value > maxFrequency)
            {
                mode = kv.Key;
                maxFrequency = kv.Value;
            }
        }

        return mode;
    }
}
