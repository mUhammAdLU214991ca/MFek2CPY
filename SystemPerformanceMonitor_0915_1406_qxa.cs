// 代码生成时间: 2025-09-15 14:06:38
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A system performance monitor tool for Unity applications.
/// </summary>
public class SystemPerformanceMonitor
{
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;
    private float lastCpuUsage;
    private float lastRamUsage;

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemPerformanceMonitor"/> class.
    /// </summary>
    public SystemPerformanceMonitor()
    {
        try
        {
            // Initialize performance counters for CPU and RAM usage
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to initialize performance counters: " + ex.Message);
        }
    }

    /// <summary>
    /// Updates the performance monitor with the latest CPU and RAM usage data.
    /// </summary>
    public void UpdatePerformanceData()
    {
        try
        {
            // Read the current CPU usage
            lastCpuUsage = cpuCounter.NextValue();
            // Read the current RAM usage
            lastRamUsage = ramCounter.NextValue();
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to update performance data: " + ex.Message);
        }
    }

    /// <summary>
    /// Gets the current CPU usage as a percentage.
    /// </summary>
    /// <returns>The current CPU usage.</returns>
    public float GetCurrentCpuUsage()
    {
        return lastCpuUsage;
    }

    /// <summary>
    /// Gets the current RAM usage in megabytes.
    /// </summary>
    /// <returns>The current RAM usage.</returns>
    public float GetCurrentRamUsage()
    {
        return lastRamUsage;
    }
}
