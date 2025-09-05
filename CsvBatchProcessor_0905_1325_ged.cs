// 代码生成时间: 2025-09-05 13:25:06
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// CSV文件批量处理器，用于处理指定目录下的所有CSV文件。
/// </summary>
public class CsvBatchProcessor
{
    /// <summary>
    /// 要处理的CSV文件目录路径。
    /// </summary>
    private readonly string directoryPath;

    /// <summary>
    /// 构造函数，初始化目录路径。
    /// </summary>
    /// <param name="directoryPath">CSV文件所在的目录路径。</param>
    public CsvBatchProcessor(string directoryPath)
    {
        this.directoryPath = directoryPath;
    }

    /// <summary>
    /// 处理目录下所有CSV文件。
    /// </summary>
    public void ProcessAllCsvFiles()
    {
        if (!Directory.Exists(directoryPath))
        {
            Debug.LogError("Directory does not exist: " + directoryPath);
            return;
        }

        string[] csvFiles = Directory.GetFiles(directoryPath, "*.csv");
        foreach (string filePath in csvFiles)
        {
            try
            {
                ProcessCsvFile(filePath);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error processing file: " + filePath + ". Exception: " + ex.Message);
            }
        }
    }

    /// <summary>
    /// 处理单个CSV文件。
    /// </summary>
    /// <param name="filePath">CSV文件的完整路径。</param>
    private void ProcessCsvFile(string filePath)
    {
        List<string[]> csvData = ReadCsvFile(filePath);
        // 在这里添加处理CSV数据的逻辑
        // 例如：保存到数据库、进行数据分析等
        Debug.Log("Processed file: " + filePath);
    }

    /// <summary>
    /// 读取CSV文件内容。
    /// </summary>
    /// <param name="filePath">CSV文件的完整路径。</param>
    /// <returns>CSV文件中的数据行。</returns>
    private List<string[]> ReadCsvFile(string filePath)
    {
        List<string[]> data = new List<string[]>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] row = line.Split(',');
                data.Add(row);
            }
        }
        return data;
    }
}
