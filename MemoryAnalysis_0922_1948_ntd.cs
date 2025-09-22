// 代码生成时间: 2025-09-22 19:48:53
using System;
using UnityEngine;
using System.Diagnostics;

/// <summary>
/// A class to analyze memory usage in Unity.
/// </summary>
public static class MemoryAnalysis
{
    /// <summary>
    /// Gets the current memory usage of the application.
    /// </summary>
    /// <returns>The current memory usage in bytes.</returns>
    public static long GetCurrentMemoryUsage()
    {
        try
        {
            // Use the Process class to get memory information.
            Process currentProcess = Process.GetCurrentProcess();
            return currentProcess.WorkingSet64;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error retrieving memory usage: " + ex.Message);
            return 0;
        }
    }

    /// <summary>
    /// Logs the current memory usage to the Unity Console.
    /// </summary>
    public static void LogMemoryUsage()
    {
        long memoryUsage = GetCurrentMemoryUsage();
        Debug.Log("Current memory usage: " + memoryUsage + " bytes");
    }

    /// <summary>
    /// Optionally, a method to estimate the memory usage of specific objects.
    /// </summary>
    /// <param name="objects">The objects to estimate memory usage for.</param>
    /// <returns>The estimated memory usage in bytes.</returns>
    public static long EstimateObjectMemoryUsage(params object[] objects)
    {
        long totalMemoryUsage = 0;
        foreach (var obj in objects)
        {
            try
            {
                // Reflection is used to get the size of the object.
                // This is a rough estimate and may not be accurate.
                var size = System.Runtime.InteropServices.Marshal.SizeOf(obj);
                totalMemoryUsage += size;
            }
            catch (Exception ex)
            {
                Debug.LogError("Error estimating memory usage for an object: " + ex.Message);
            }
        }
        return totalMemoryUsage;
    }
}
