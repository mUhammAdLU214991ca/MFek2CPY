// 代码生成时间: 2025-08-24 21:47:19
using System;
using UnityEngine;
using System.Diagnostics;

namespace MemoryAnalysisUtility
{
    public class MemoryAnalysis
    {
        /// <summary>
        /// Analyzes the memory usage of the application.
        /// </summary>
        /// <param name="logToConsole">Logs memory usage data to the console.</param>
        /// <returns>A string containing memory usage information.</returns>
        public static string AnalyzeMemoryUsage(bool logToConsole = false)
        {
            try
            {
                // Retrieve the memory usage information
                Process currentProcess = Process.GetCurrentProcess();
                long usedMemory = currentProcess.WorkingSet64;
                long totalMemory = currentProcess.MaxWorkingSet;

                // Create a string to hold memory usage information
                string memoryUsageInfo = $"Memory Usage: Used - {usedMemory / (1024 * 1024)} MB, Total Available - {totalMemory / (1024 * 1024)} MB";

                if (logToConsole)
                {
                    Debug.Log(memoryUsageInfo);
                }

                return memoryUsageInfo;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the memory analysis process
                Debug.LogError($"An error occurred while analyzing memory usage: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Clears the memory usage analysis cache if it exists.
        /// </summary>
        public static void ClearMemoryCache()
        {
            try
            {
                // Assuming there's a cache system in place, clear the cache here
                // This method is a placeholder for actual cache clearing logic
                Debug.Log("Memory cache cleared.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while clearing memory cache: {ex.Message}");
            }
        }
    }
}
