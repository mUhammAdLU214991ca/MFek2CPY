// 代码生成时间: 2025-10-10 22:47:53
 * It includes error handling, comments, and follows C# best practices for maintainability and scalability.
 */

using System;
using UnityEngine;

public class LearningProgressTracker : MonoBehaviour
{
    // Represents the maximum progress value that can be achieved.
    private const int MaxProgress = 100;

    // Current progress of the user.
    private int currentProgress = 0;

    // Method to start tracking progress.
    public void StartTracking()
    {
        Debug.Log("Starting to track learning progress.");
        currentProgress = 0;
    }

    // Method to advance the learning progress by a given amount.
    public void AdvanceProgress(int progressAmount)
    {
        // Check for invalid progress amounts.
        if (progressAmount < 0)
        {
            Debug.LogError("Cannot advance progress by a negative amount.");
            return;
        }

        // Update the current progress.
        currentProgress += progressAmount;

        // Ensure the progress does not exceed the maximum.
        if (currentProgress > MaxProgress)
        {
            currentProgress = MaxProgress;
        }

        // Log the current progress.
        Debug.Log($"Progress updated: {currentProgress}%");
    }

    // Method to reset the learning progress to zero.
    public void ResetProgress()
    {
        // Reset the current progress.
        currentProgress = 0;
        Debug.Log("Learning progress has been reset.");
    }

    // Method to check if the learning progress is complete.
    public bool IsProgressComplete()
    {
        // Return true if the current progress is equal to the maximum progress.
        return currentProgress >= MaxProgress;
    }

    // Method to get the current progress in percentage.
    public int GetCurrentProgress()
    {
        // Return the current progress.
        return currentProgress;
    }
}
