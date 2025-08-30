// 代码生成时间: 2025-08-31 06:08:10
using System;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// 文件备份和同步工具
/// </summary>
public class FileBackupAndSync
{
    private string sourcePath;
    private string backupPath;

    /// <summary>
    /// 构造函数，初始化源路径和备份路径
    /// </summary>
    /// <param name="sourcePath">源路径</param>
    /// <param name="backupPath">备份路径</param>
    public FileBackupAndSync(string sourcePath, string backupPath)
    {
        this.sourcePath = sourcePath;
        this.backupPath = backupPath;
    }

    /// <summary>
    /// 同步文件
    /// </summary>
    public void SyncFiles()
    {
        try
        {
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

            var sourceFiles = Directory.GetFiles(sourcePath);
            foreach (var file in sourceFiles)
            {
                var fileName = Path.GetFileName(file);
                var backupFile = Path.Combine(backupPath, fileName);

                // 如果文件已存在，则进行覆盖
                if (File.Exists(backupFile))
                {
                    File.Delete(backupFile);
                }

                File.Copy(file, backupFile, true);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("同步文件时发生错误：" + ex.Message);
        }
    }

    /// <summary>
    /// 备份文件
    /// </summary>
    public void BackupFiles()
    {
        try
        {
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

            var sourceFiles = Directory.GetFiles(sourcePath);
            foreach (var file in sourceFiles)
            {
                var fileName = Path.GetFileName(file);
                var backupFile = Path.Combine(backupPath, fileName);

                // 备份文件
                File.Copy(file, backupFile, true);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("备份文件时发生错误：" + ex.Message);
        }
    }
}
