// 代码生成时间: 2025-09-09 09:16:32
using System;
using UnityEngine;

/// <summary>
/// A class that demonstrates the implementation of search algorithm optimization.
/// </summary>
public class SearchAlgorithmOptimization : MonoBehaviour
{
    /// <summary>
    /// Searches for a target value in a given array using a binary search algorithm.
    /// </summary>
    /// <param name="array">The sorted array to search in.</param>
    /// <param name="target">The target value to search for.</param>
    /// <returns>The index of the target value if found, otherwise -1.</returns>
    public int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int midValue = array[mid];

            if (midValue == target)
            {
                return mid; // Target found
            }
            else if (midValue < target)
            {
                left = mid + 1; // Search in the right half
            }
            else
            {
                right = mid - 1; // Search in the left half
            }
        }

        return -1; // Target not found
    }

    /// <summary>
    /// Searches for a target value in a given array using a linear search algorithm.
    /// </summary>
    /// <param name="array">The array to search in.</param>
    /// <param name="target">The target value to search for.</param>
    /// <returns>The index of the target value if found, otherwise -1.</returns>
    public int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i; // Target found
            }
        }

        return -1; // Target not found
    }

    private void Start()
    {
        try
        {
            int[] testArray = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int targetValue = 11;

            // Perform binary search
            int binaryIndex = BinarySearch(testArray, targetValue);
            Debug.Log($"Binary search result for {targetValue}: Index {binaryIndex}");

            // Perform linear search
            int linearIndex = LinearSearch(testArray, targetValue);
            Debug.Log($"Linear search result for {targetValue}: Index {linearIndex}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred: {ex.Message}");
        }
    }
}
