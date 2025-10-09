// 代码生成时间: 2025-10-10 02:09:25
 * Author: [Your Name]
 * Date: [Today's Date]
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class MemoryAnalysis
{
    // Delegate for memory analysis event
    public delegate void MemoryAnalysisEventHandler(float memoryUsageMB);
    public event MemoryAnalysisEventHandler OnMemoryAnalysis;

    // Unity's memory profile is not thread-safe, so we use this to lock access
    private static readonly object memoryProfileLock = new object();

    // Method to log current memory usage
    public static void LogCurrentMemoryUsage()
    {
        try
        {
            lock (memoryProfileLock)
            {
                ulong memoryUsage = GC.GetTotalMemory(false);
                Debug.Log($"Total Allocated Memory: {memoryUsage} bytes");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error logging memory usage: {ex.Message}");
        }
    }

    // Method to take a snapshot of memory usage
    public static void TakeMemorySnapshot()
    {
        try
        {
            ulong memoryUsage = GC.GetTotalMemory(true);
            Debug.Log($"Total Memory: {memoryUsage} bytes");
            OnMemoryAnalysis?.Invoke(memoryUsage / (1024.0f * 1024.0f)); // Convert bytes to MB and invoke event
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error taking memory snapshot: {ex.Message}");
        }
    }

    // Method to log memory usage over time
    public static void LogMemoryUsageOverTime()
    {
        try
        {
            ulong memoryUsage = GC.GetTotalMemory(false);            
            Debug.Log($"Memory Usage Over Time: {memoryUsage} bytes");
            OnMemoryAnalysis?.Invoke(memoryUsage / (1024.0f * 1024.0f)); // Convert bytes to MB and invoke event
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error logging memory usage over time: {ex.Message}");
        }
    }

    // Example usage of the memory analysis class
    public static void Main()
    {
        // Subscribe to the event to handle memory analysis data
        OnMemoryAnalysis += (memoryUsageMB) =>
        {
            Debug.Log($"Memory usage reported in MB: {memoryUsageMB}");
        };

        // Log current memory usage
        LogCurrentMemoryUsage();

        // Take a snapshot of memory usage
        TakeMemorySnapshot();

        // Log memory usage over time (this could be called periodically, e.g., every frame or every minute)
        LogMemoryUsageOverTime();
    }
}
