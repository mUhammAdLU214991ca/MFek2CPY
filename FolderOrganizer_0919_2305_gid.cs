// 代码生成时间: 2025-09-19 23:05:11
// FolderOrganizer.cs
// 这个类负责整理指定文件夹结构。
using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class FolderOrganizer
{
    // 构造函数，接受要整理的文件夹路径。
    public FolderOrganizer(string folderPath)
    {
        if (string.IsNullOrEmpty(folderPath))
        {
            throw new ArgumentException("Folder path cannot be null or empty.");
        }

        FolderPath = folderPath;
    }

    // 要整理的文件夹路径。
    private string FolderPath { get; }

    // 整理文件夹结构的方法。
    public void OrganizeFolderStructure()
    {
        try
        {
            // 检查文件夹路径是否存在。
            if (!Directory.Exists(FolderPath))
            {
                Debug.LogError("The specified folder does not exist.");
                return;
            }

            // 获取所有文件和文件夹。
            var files = Directory.GetFiles(FolderPath);
            var directories = Directory.GetDirectories(FolderPath);

            // 按照文件扩展名分类整理文件。
            foreach (var file in files)
            {
                string extension = Path.GetExtension(file).ToUpper();
                string targetDirectory = Path.Combine(FolderPath, extension);

                // 如果目标文件夹不存在，则创建。
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // 移动文件到目标文件夹。
                File.Move(file, Path.Combine(targetDirectory, Path.GetFileName(file)));
            }

            // 递归整理子文件夹。
            foreach (var directory in directories)
            {
                new FolderOrganizer(directory).OrganizeFolderStructure();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while organizing the folder structure: {ex.Message}");
        }
    }
}
