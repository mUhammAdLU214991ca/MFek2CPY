// 代码生成时间: 2025-08-03 06:30:26
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A simple system performance monitor tool for Unity.
/// </summary>
public class SystemPerformanceMonitor
{
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;

    /// <summary>
    /// Initializes a new instance of the SystemPerformanceMonitor class.
    /// </summary>
    public SystemPerformanceMonitor()
    {
        // Initialize performance counters for CPU and RAM
        try
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to initialize performance counters: " + ex.Message);
        }
    }

    /// <summary>
    /// Gets the current CPU usage as a percentage.
    /// </summary>
    /// <returns>The CPU usage percentage.</returns>
    public float GetCpuUsage()
    {
        try
        {
            return cpuCounter.NextValue();
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to get CPU usage: " + ex.Message);
            return 0;
        }
    }

    /// <summary>
    /// Gets the current available RAM in megabytes.
    /// </summary>
    /// <returns>The available RAM in MB.</returns>
    public float GetAvailableRam()
    {
        try
        {
            return ramCounter.NextValue();
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to get available RAM: " + ex.Message);
            return 0;
        }
    }

    /// <summary>
    /// Logs the current system performance metrics to the Unity console.
    /// </summary>
    public void LogSystemPerformance()
    {
        float cpuUsage = GetCpuUsage();
        float availableRam = GetAvailableRam();
        Debug.Log("CPU Usage: " + cpuUsage + "%");
        Debug.Log("Available RAM: " + availableRam + " MB");
    }
}
