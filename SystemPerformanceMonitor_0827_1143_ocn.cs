// 代码生成时间: 2025-08-27 11:43:07
using System;
using System.Collections;
using UnityEngine;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class SystemPerformanceMonitor : MonoBehaviour
{
    // Update interval in seconds
    private float updateTimer;
    public float UpdateInterval = 1.0f;

    // Properties to hold system performance data
    private float cpuUsage;
    private float memoryUsage;
    private float frameRate;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        updateTimer = UpdateInterval;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        updateTimer -= Time.deltaTime;

        if (updateTimer <= 0)
        {
            UpdateSystemMetrics();
            updateTimer = UpdateInterval;
        }
    }

    /// <summary>
    /// Updates the system performance metrics
    /// </summary>
    private void UpdateSystemMetrics()
    {
        try
        {
            // Get CPU usage
            cpuUsage = GetCpuUsage();

            // Get memory usage
            memoryUsage = GetMemoryUsage();

            // Calculate frame rate
            frameRate = 1.0f / Time.deltaTime;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error updating system metrics: " + ex.Message);
        }
    }

    /// <summary>
    /// Gets the CPU usage percentage
    /// </summary>
    /// <returns>The CPU usage percentage</returns>
    private float GetCpuUsage()
    {
        // Implementation of CPU usage calculation depends on the platform.
        // For simplicity, this returns a placeholder value.
        return 0.5f; // Placeholder value
    }

    /// <summary>
    /// Gets the memory usage in MB
    /// </summary>
    /// <returns>The memory usage in MB</returns>
    private float GetMemoryUsage()
    {
        return (float)GC.GetTotalMemory(false) / (1024 * 1024); // Convert bytes to MB
    }

    /// <summary>
    /// Displays the system performance metrics in the console
    /// </summary>
    private void DisplaySystemMetrics()
    {
        Debug.Log($"CPU Usage: {cpuUsage}%
Memory Usage: {memoryUsage} MB
Frame Rate: {frameRate} FPS");
    }
}
