// 代码生成时间: 2025-08-19 12:49:01
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// 文件同步和备份工具类
public class FileSyncUtility
{
    // 源文件夹路径
    private string sourceFolder;
    // 目标文件夹路径
    private string targetFolder;

    public FileSyncUtility(string sourcePath, string targetPath)
    {
        sourceFolder = sourcePath;
        targetFolder = targetPath;
    }

    // 同步文件夹内容
    public void SynchronizeFolders()
    {
        try
        {
            // 获取源文件夹和目标文件夹的文件信息
            var sourceFiles = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);
            var targetFiles = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);

            // 同步文件
            foreach (var sourceFile in sourceFiles)
            {
                var relativePath = GetRelativePath(sourceFolder, sourceFile);
                var targetFilePath = Path.Combine(targetFolder, relativePath);

                if (!File.Exists(targetFilePath) || File.GetLastWriteTimeUtc(sourceFile) > File.GetLastWriteTimeUtc(targetFilePath))
                {
                    // 确保目标文件夹路径存在
                    Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath));

                    // 复制文件到目标文件夹
                    File.Copy(sourceFile, targetFilePath, true);
                }
            }

            // 删除目标文件夹中不在源文件夹的文件
            foreach (var targetFile in targetFiles)
            {
                var relativePath = GetRelativePath(targetFolder, targetFile);
                var sourceFilePath = Path.Combine(sourceFolder, relativePath);

                if (!File.Exists(sourceFilePath))
                {
                    File.Delete(targetFile);
                }
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"Error synchronizing folders: {ex.Message}");
        }
    }

    // 获取相对路径
    private string GetRelativePath(string basePath, string fullPath)
    {
        var relativePath = fullPath.Substring(basePath.Length).TrimStart(Path.DirectorySeparatorChar);
        return relativePath;
    }

    // 主入口方法
    public static void Main(string[] args)
    {
        // 示例：同步C:	emp 到D:\backup
        FileSyncUtility syncUtility = new FileSyncUtility("C:\	emp", "D:\backup");
        syncUtility.SynchronizeFolders();
    }
}
