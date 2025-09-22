// 代码生成时间: 2025-09-23 06:01:51
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 文件备份和同步工具类
/// </summary>
public class FileBackupSyncTool
{
    /// <summary>
    /// 执行文件备份
    /// </summary>
    /// <param name="sourcePath">源文件路径</param>
    /// <param name="backupPath">备份文件路径</param>
    public static async Task BackupFileAsync(string sourcePath, string backupPath)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                Debug.LogError($"源文件 {sourcePath} 不存在");
                return;
            }

            await Task.Run(() =>
            {
                File.Copy(sourcePath, backupPath, true);
            });

            Debug.Log($"文件从 {sourcePath} 备份到 {backupPath} 完成");
        }
        catch (Exception ex)
        {
            Debug.LogError($"备份文件时发生错误: {ex.Message}");
        }
    }

    /// <summary>
    /// 执行文件同步
    /// </summary>
    /// <param name="sourcePath">源文件路径</param>
    /// <param name="targetPath">目标文件路径</param>
    public static async Task SyncFileAsync(string sourcePath, string targetPath)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                Debug.LogError($"源文件 {sourcePath} 不存在");
                return;
            }

            await Task.Run(() =>
            {
                File.Copy(sourcePath, targetPath, true);
            });

            Debug.Log($"文件从 {sourcePath} 同步到 {targetPath} 完成");
        }
        catch (Exception ex)
        {
            Debug.LogError($"同步文件时发生错误: {ex.Message}");
        }
    }
}
