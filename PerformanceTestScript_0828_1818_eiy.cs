// 代码生成时间: 2025-08-28 18:18:29
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A performance testing script for unity projects.
/// This script measures the time taken by a specified action and logs the result.
/// </summary>
public class PerformanceTestScript : MonoBehaviour
{
    /// <summary>
    /// The action to be tested for performance.
    /// </summary>
    private Action performAction;

    /// <summary>
    /// The number of iterations to perform for the test.
    /// </summary>
    private int numberOfIterations = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="PerformanceTestScript"/> class.
    /// </summary>
    /// <param name="action">The action to be tested.</param>
    /// <param name="iterations">The number of iterations.</param>
    public void Initialize(Action action, int iterations = 100)
    {
        performAction = action ?? throw new ArgumentNullException(nameof(action));
        numberOfIterations = iterations;
    }

    /// <summary>
    /// Starts the performance test.
    /// </summary>
    public void StartTest()
    {
        if (performAction == null)
        {
            Debug.LogError("No action has been initialized for performance testing.");
            return;
        }

        float totalElapsedTime = 0f;
        for (int i = 0; i < numberOfIterations; i++)
        {
            float startTime = Time.realtimeSinceStartup;
            try
            {
                performAction();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error during performance test iteration {i}: {ex.Message}");
                return;
            }
            float endTime = Time.realtimeSinceStartup;
            totalElapsedTime += (endTime - startTime);
        }

        float averageTime = totalElapsedTime / numberOfIterations;
        Debug.Log($"Performance Test Results:
Total Elapsed Time: {totalElapsedTime} seconds
Average Time per Iteration: {averageTime} seconds");
    }

    // Example usage:
    // PerformanceTestScript testScript = new PerformanceTestScript();
    // testScript.Initialize(() => { /* your code to test */ });
    // testScript.StartTest();
}
