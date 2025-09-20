// 代码生成时间: 2025-09-20 22:00:23
using System;
# 添加错误处理
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 图片尺寸批量调整器，用于处理Unity游戏项目中的图片尺寸调整问题。
/// </summary>
public static class ImageResizer
{
# 优化算法效率
    /// <summary>
    /// 调整指定文件夹内所有图片的尺寸。
    /// </summary>
    /// <param name="sourceFolder">源文件夹路径，包含要调整尺寸的图片。</param>
# TODO: 优化性能
    /// <param name="destinationFolder">目标文件夹路径，调整尺寸后的图片将被保存。</param>
    /// <param name="newWidth">新的宽度。</param>
    /// <param name="newHeight">新的高度。</param>
    /// <param name="formats">要处理的图片格式列表。</param>
    public static void ResizeImages(string sourceFolder, string destinationFolder, int newWidth, int newHeight, List<string> formats)
    {
        if (string.IsNullOrEmpty(sourceFolder) || string.IsNullOrEmpty(destinationFolder))
        {
            Debug.LogError("Source or destination folder path is null or empty.");
            return;
        }

        // 确保目标文件夹存在
        if (!Directory.Exists(destinationFolder))
        {
            Directory.CreateDirectory(destinationFolder);
        }

        string[] files = Directory.GetFiles(sourceFolder);
        foreach (string file in files)
# 扩展功能模块
        {
            string extension = Path.GetExtension(file).ToLowerInvariant();
            if (formats.Contains(extension))
            {
                try
# TODO: 优化性能
                {
                    // 加载图片
                    Texture2D texture = LoadTexture(file);
                    if (texture != null)
                    {
# 增强安全性
                        // 调整图片尺寸
                        Texture2D resizedTexture = ResizeTexture(texture, newWidth, newHeight);
                        if (resizedTexture != null)
                        {
                            // 保存调整后的图片
                            string filename = Path.GetFileName(file);
                            string newFilePath = Path.Combine(destinationFolder, filename);
# FIXME: 处理边界情况
                            SaveTexture(resizedTexture, newFilePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error resizing image {file}: {ex.Message}");
                }
            }
        }
    }

    /// <summary>
# 添加错误处理
    /// 加载图片。
# 扩展功能模块
    /// </summary>
    /// <param name="filePath">图片文件路径。</param>
    /// <returns>加载的Texture2D对象，如果加载失败则返回null。</returns>
    private static Texture2D LoadTexture(string filePath)
    {
        try
# NOTE: 重要实现细节
        {
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes(filePath));
            return texture;
        }
        catch (Exception)
        {
            return null;
        }
# TODO: 优化性能
    }

    /// <summary>
    /// 调整Texture2D对象的尺寸。
    /// </summary>
    /// <param name="sourceTexture">原始Texture2D对象。</param>
    /// <param name="newWidth">新的宽度。</param>
    /// <param name="newHeight">新的高度。</param>
    /// <returns>调整尺寸后的Texture2D对象。</returns>
    private static Texture2D ResizeTexture(Texture2D sourceTexture, int newWidth, int newHeight)
    {
        Texture2D resizedTexture = new Texture2D(newWidth, newHeight);
        // 调整图片尺寸
        TextureScaler.Resize(resizedTexture, sourceTexture, newWidth, newHeight);
# 优化算法效率
        return resizedTexture;
    }

    /// <summary>
    /// 保存Texture2D对象为文件。
# TODO: 优化性能
    /// </summary>
    /// <param name="texture">要保存的Texture2D对象。</param>
    /// <param name="filePath">文件保存路径。</param>
    private static void SaveTexture(Texture2D texture, string filePath)
    {
# 优化算法效率
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
    }
}
# NOTE: 重要实现细节
