// 代码生成时间: 2025-09-14 20:03:45
using System;
using System.Collections.Generic;
using UnityEngine;

public class SortingAlgorithms : MonoBehaviour
{
    // A simple bubble sort algorithm implementation.
    public void BubbleSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Debug.LogError("Array is null or empty.");
            return;
        }

        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    // Swap the elements.
                    int temp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

    // A simple selection sort algorithm implementation.
    public void SelectionSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Debug.LogError("Array is null or empty.");
            return;
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                // Swap the elements.
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    // A simple insertion sort algorithm implementation.
    public void InsertionSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Debug.LogError("Array is null or empty.");
            return;
        }

        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }

    // Example usage of sorting algorithms.
    void Start()
    {
        int[] numbers = { 4, 2, 3, 5, 1, 6 };
        Debug.Log("Original array: " + string.Join(", ", numbers));

        BubbleSort(numbers);
        Debug.Log("Sorted array (Bubble Sort): " + string.Join(", ", numbers));

        numbers = new int[] { 4, 2, 3, 5, 1, 6 };
        SelectionSort(numbers);
        Debug.Log("Sorted array (Selection Sort): " + string.Join(", ", numbers));

        numbers = new int[] { 4, 2, 3, 5, 1, 6 };
        InsertionSort(numbers);
        Debug.Log("Sorted array (Insertion Sort): " + string.Join(", ", numbers));
    }
}
