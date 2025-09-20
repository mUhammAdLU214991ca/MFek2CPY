// 代码生成时间: 2025-09-20 11:02:43
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageResizer : MonoBehaviour
{
    // The target directory for the resized images
    public string outputDirectory = "ResizedImages";
    // The desired width for the resized images
    public int targetWidth = 1024;
    // The desired height for the resized images
    public int targetHeight = 768;

    private void Start()
    {
        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);
        ResizeImages();
    }

    /// <summary>
    /// Resizes all images in the specified directory.
    /// </summary>
    private void ResizeImages()
    {
        string[] filePaths = Directory.GetFiles(Application.dataPath, "*.png");

        foreach (string filePath in filePaths)
        {
            try
            {
                Debug.Log($"Resizing image: {filePath}");
                Texture2D texture = LoadTexture(filePath);
                Texture2D resizedTexture = ResizeTexture(texture);
                SaveTexture(resizedTexture, Path.Combine(outputDirectory, Path.GetFileName(filePath)));
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error resizing image: {filePath}. Exception: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Loads a texture from the specified file path.
    /// </summary>
    private Texture2D LoadTexture(string filePath)
    {
        Texture2D texture = new Texture2D(2, 2);
        byte[] fileData = File.ReadAllBytes(filePath);
        texture.LoadImage(fileData);
        return texture;
    }

    /// <summary>
    /// Resizes the given texture to the target width and height.
    /// </summary>
    private Texture2D ResizeTexture(Texture2D texture)
    {
        Texture2D resizedTexture = new Texture2D(targetWidth, targetHeight);
        TextureScaler.Scale(texture, resizedTexture);
        return resizedTexture;
    }

    /// <summary>
    /// Saves the texture to the specified file path.
    /// </summary>
    private void SaveTexture(Texture2D texture, string filePath)
    {
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
        Debug.Log($"Image saved to: {filePath}");
    }
}
