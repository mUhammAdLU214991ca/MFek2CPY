// 代码生成时间: 2025-09-03 14:14:02
 * Requirements:
# 改进用户体验
 * - Unity Engine
 * - .NET 4.x or higher
# FIXME: 处理边界情况
 *
 * Usage:
 * 1. Attach this script to a GameObject in your Unity scene.
 * 2. Provide paths to the folder containing the images you want to resize.
# 扩展功能模块
 * 3. Set the desired target size for the images.
 * 4. Call the ResizeImages method to start the resizing process.
 */

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageResizer : MonoBehaviour
{
    /// <summary>
    /// The directory containing the images to resize.
    /// </summary>
    public string sourceDirectory;

    /// <summary>
# FIXME: 处理边界情况
    /// The directory where resized images will be saved.
# TODO: 优化性能
    /// </summary>
    public string targetDirectory;

    /// <summary>
    /// The target width for the resized images.
    /// </summary>
    public int targetWidth;

    /// <summary>
    /// The target height for the resized images.
    /// </summary>
# TODO: 优化性能
    public int targetHeight;

    /// <summary>
    /// Resizes all images in the source directory to the specified dimensions.
# TODO: 优化性能
    /// </summary>
# 改进用户体验
    public void ResizeImages()
    {
        if (string.IsNullOrEmpty(sourceDirectory) || string.IsNullOrEmpty(targetDirectory))
        {
            Debug.LogError("Source and target directories must be set.");
            return;
        }

        if (!Directory.Exists(sourceDirectory))
        {
            Debug.LogError($"Source directory does not exist: {sourceDirectory}");
            return;
        }

        if (!Directory.Exists(targetDirectory))
        {
            Directory.CreateDirectory(targetDirectory);
        }

        string[] imageFiles = Directory.GetFiles(sourceDirectory, "*.png"); // Supports PNG files. Extend for other formats.

        foreach (string filePath in imageFiles)
        {
            try
            {
# NOTE: 重要实现细节
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(File.ReadAllBytes(filePath));

                // Calculate new size while maintaining aspect ratio
                Rect originalRect = new Rect(0, 0, texture.width, texture.height);
                Rect resizedRect = new Rect(0, 0, targetWidth, targetHeight);
                float aspectRatio = originalRect.width / (float)originalRect.height;

                if (targetWidth / (float)targetHeight > aspectRatio)
                {
                    resizedRect.width = (int)(targetHeight * aspectRatio);
                }
                else
                {
                    resizedRect.height = (int)(targetWidth / aspectRatio);
                }
# 扩展功能模块

                // Resize the texture
                Texture2D resizedTexture = new Texture2D(targetWidth, targetHeight);
                Graphics.CopyTexture(texture, resizedTexture);
                resizedTexture.Resize(resizedTexture.width, resizedTexture.height);

                // Save the resized texture
                string targetPath = Path.Combine(targetDirectory, Path.GetFileName(filePath));
                File.WriteAllBytes(targetPath, resizedTexture.EncodeToPNG());

                Debug.Log($"Resized and saved image: {targetPath}");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error resizing image {filePath}: {e.Message}");
            }
# TODO: 优化性能
        }
    }
}
