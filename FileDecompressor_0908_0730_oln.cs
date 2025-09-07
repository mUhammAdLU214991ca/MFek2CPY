// 代码生成时间: 2025-09-08 07:30:33
using System;
using System.IO;
using System.IO.Compression;

namespace FileDecompressor
{
    public class FileDecompressor
    {
        // 解压文件的函数
        public static void Decompress(string archivePath, string destinationPath)
        {
            // 检查路径是否有效
            if (string.IsNullOrEmpty(archivePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException("Archive and destination paths cannot be null or empty.");
            }

            try
            {
                // 确保目标解压路径存在
                Directory.CreateDirectory(destinationPath);

                // 使用ZipFile类来解压文件
                ZipFile.ExtractToDirectory(archivePath, destinationPath);
            }
            catch (IOException ioEx)
            {
                // 处理文件输入输出异常
                Console.WriteLine($"An I/O error occurred: {ioEx.Message}");
                throw;
            }
            catch (InvalidDataException invDataEx)
            {
                // 处理无效数据异常，例如损坏的压缩文件
                Console.WriteLine($"The archive is invalid or corrupted: {invDataEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // 处理其他潜在的异常
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
