// 代码生成时间: 2025-10-11 21:15:52
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DataPartitioningTool is a utility class that handles data partitioning and sharding.
/// It aims to split large datasets into smaller, manageable chunks.
/// </summary>
public class DataPartitioningTool
{
    /// <summary>
    /// Partitions a list of data into a specified number of partitions.
    /// </summary>
    /// <typeparam name="T">The type of data in the list.</typeparam>
    /// <param name="dataList">The list of data to partition.</param>
    /// <param name="numberOfPartitions">The number of partitions to create.</param>
    /// <returns>A list of lists, each representing a partition of the original data.</returns>
    public static List<List<T>> PartitionData<T>(List<T> dataList, int numberOfPartitions)
    {
        if (dataList == null)
        {
            throw new ArgumentNullException(nameof(dataList), "Data list cannot be null.");
        }

        if (numberOfPartitions <= 0)
        {
            throw new ArgumentException("Number of partitions must be a positive integer.", nameof(numberOfPartitions));
        }

        if (dataList.Count == 0)
        {
            return new List<List<T>>();
        }

        int partitionSize = dataList.Count / numberOfPartitions;
        int remainder = dataList.Count % numberOfPartitions;

        List<List<T>> partitions = new List<List<T>>(numberOfPartitions);

        for (int i = 0; i < numberOfPartitions; i++)
        {
            int start = i * partitionSize;
            int end = start + partitionSize;
            if (i < remainder)
            {
                end++;
            }

            partitions.Add(dataList.GetRange(start, end - start));
        }

        return partitions;
    }

    /// <summary>
    /// Shards a list of data into a specified number of shards.
    /// </summary>
    /// <typeparam name="T">The type of data in the list.</typeparam>
    /// <param name="dataList">The list of data to shard.</param>
    /// <param name="shardSize">The size of each shard.</param>
    /// <returns>A list of lists, each representing a shard of the original data.</returns>
    public static List<List<T>> ShardData<T>(List<T> dataList, int shardSize)
    {
        if (dataList == null)
        {
            throw new ArgumentNullException(nameof(dataList), "Data list cannot be null.");
        }

        if (shardSize <= 0)
        {
            throw new ArgumentException("Shard size must be a positive integer.", nameof(shardSize));
        }

        if (dataList.Count == 0)
        {
            return new List<List<T>>();
        }

        int numberOfShards = dataList.Count / shardSize;
        if (dataList.Count % shardSize != 0)
        {
            numberOfShards++;
        }

        List<List<T>> shards = new List<List<T>>(numberOfShards);

        for (int i = 0; i < numberOfShards; i++)
        {
            int start = i * shardSize;
            int end = Math.Min(start + shardSize, dataList.Count);

            shards.Add(dataList.GetRange(start, end - start));
        }

        return shards;
    }
}
