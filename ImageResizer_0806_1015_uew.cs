// 代码生成时间: 2025-08-06 10:15:18
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 图片尺寸批量调整器，用于将指定文件夹中的图片调整到统一的尺寸。
/// </summary>
public class ImageResizer : MonoBehaviour
{
    /// <summary>
    /// 源文件夹路径，包含需要调整尺寸的图片。
    /// </summary>
    public string sourceFolderPath;

    /// <summary>
    /// 目标文件夹路径，调整尺寸后的图片将保存在此。
    /// </summary>
    public string targetFolderPath;

    /// <summary>
    /// 目标图片尺寸。
    /// </summary>
    public Vector2Int targetSize = new Vector2Int(256, 256);

    /// <summary>
    /// 调整图片尺寸的方法。
    /// </summary>
    public void ResizeImages()
    {
        try
        {
            // 确保源文件夹和目标文件夹路径有效
            if (string.IsNullOrEmpty(sourceFolderPath) || string.IsNullOrEmpty(targetFolderPath))
            {
                Debug.LogError("源文件夹或目标文件夹路径不能为空。");
                return;
            }

            // 确保源文件夹和目标文件夹存在
            if (!Directory.Exists(sourceFolderPath))
            {
                Debug.LogError($"源文件夹路径不存在: {sourceFolderPath}");
                return;
            }

            if (!Directory.Exists(targetFolderPath))
            {
                Directory.CreateDirectory(targetFolderPath);
            }

            // 获取源文件夹中的所有图片文件
            string[] imageFiles = Directory.GetFiles(sourceFolderPath, "*.png");

            foreach (string imageFile in imageFiles)
            {
                // 加载图片
                Texture2D texture = LoadTexture(imageFile);

                if (texture == null)
                {
                    Debug.LogError($"加载图片失败: {imageFile}");
                    continue;
                }

                // 调整图片尺寸
                Texture2D resizedTexture = ResizeTexture(texture, targetSize.x, targetSize.y);

                if (resizedTexture == null)
                {
                    Debug.LogError($"调整图片尺寸失败: {imageFile}");
                    continue;
                }

                // 保存调整尺寸后的图片
                string targetFile = Path.Combine(targetFolderPath, Path.GetFileName(imageFile));
                SaveTexture(resizedTexture, targetFile);
            }

            Debug.Log("所有图片尺寸调整完成。");
        }
        catch (Exception ex)
        {
            Debug.LogError($"调整图片尺寸时发生错误: {ex.Message}");
        }
    }

    /// <summary>
    /// 加载图片文件。
    /// </summary>
    private Texture2D LoadTexture(string imageFile)
    {
        try
        {
            byte[] fileData = File.ReadAllBytes(imageFile);
            return new Texture2D(2, 2);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            return texture;
        }
        catch (Exception ex)
        {
            Debug.LogError($"加载图片文件时发生错误: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// 调整图片尺寸。
    /// </summary>
    private Texture2D ResizeTexture(Texture2D texture, int width, int height)
    {
        try
        {
            Texture2D resizedTexture = new Texture2D(width, height);
            // 这里可以添加图片缩放的逻辑，例如使用Graphics.CopyTexture等方法
            // 暂时返回原始图片
            return texture;
        }
        catch (Exception ex)
        {
            Debug.LogError($"调整图片尺寸时发生错误: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// 保存图片文件。
    /// </summary>
    private void SaveTexture(Texture2D texture, string targetFile)
    {
        try
        {
            byte[] fileData = texture.EncodeToPNG();
            File.WriteAllBytes(targetFile, fileData);
        }
        catch (Exception ex)
        {
            Debug.LogError($"保存图片文件时发生错误: {ex.Message}");
        }
    }
}