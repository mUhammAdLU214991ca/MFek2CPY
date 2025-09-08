// 代码生成时间: 2025-09-08 20:19:57
// <summary>
// 文件分析器类，用于分析文本文件内容
// </summary>
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextFileAnalyzer
{
    // <summary>
    // 分析文本文件内容
    // </summary>
    // <param name="filePath">文件路径</param>
    // <returns>分析结果</returns>
    public Dictionary<string, int> AnalyzeTextFile(string filePath)
    {
        try
        {
            // 确保文件路径不为空
            if (string.IsNullOrEmpty(filePath))
            {
                Debug.LogError("文件路径不能为空");
                return null;
            }

            // 读取文件内容
            string fileContent = File.ReadAllText(filePath);

            // 分词统计词频
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] words = fileContent.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?', '
', '', '	' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                word = word.Trim().ToLowerInvariant();
                if (word != string.Empty)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }
            }

            // 返回词频统计结果
            return wordCount;
        }
        catch (Exception ex)
        {
            // 错误处理
            Debug.LogError($"分析文件时发生错误：{ex.Message}");
            return null;
        }
    }
}
