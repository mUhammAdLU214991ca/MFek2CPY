// 代码生成时间: 2025-08-06 15:43:10
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageResizer : MonoBehaviour
{
    // Path to the folder containing images to resize
    public string sourceFolderPath = "path/to/source/folder";

    // Path to the folder where resized images will be saved
    public string targetFolderPath = "path/to/target/folder";

    // Desired dimensions for the resized images
    public int targetWidth = 1024;
    public int targetHeight = 768;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the source folder exists
        if (!Directory.Exists(sourceFolderPath))
        {
            Debug.LogError("Source folder does not exist: " + sourceFolderPath);
            return;
        }

        // Check if the target folder exists, if not, create it
        if (!Directory.Exists(targetFolderPath))
        {
            Directory.CreateDirectory(targetFolderPath);
        }

        // Get all image files in the source folder
        string[] files = Directory.GetFiles(sourceFolderPath, "*.png");

        // Resize each image file
        foreach (string file in files)
        {
            ResizeImageFile(file);
        }
    }

    // Method to resize a single image file
    private void ResizeImageFile(string filePath)
    {
        try
        {
            // Load the image from file path
            Texture2D texture = new Texture2D(2, 2);
            byte[] fileData = File.ReadAllBytes(filePath);
            texture.LoadImage(fileData);

            // Calculate new dimensions to maintain aspect ratio
            Rect sourceRect = new Rect(0, 0, texture.width, texture.height);
            Rect targetRect = new Rect(0, 0, targetWidth, targetHeight);
            Vector2 targetSize = CalculateTargetSize(sourceRect, targetRect);

            // Resize the image
            Texture2D resizedTexture = ResizeTexture(texture, (int)targetSize.x, (int)targetSize.y);

            // Save the resized image to the target folder
            string targetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(filePath));
            File.WriteAllBytes(targetFilePath, resizedTexture.EncodeToPNG());

            // Destroy the texture to free up memory
            DestroyObject(resizedTexture);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error resizing image: " + e.Message);
        }
    }

    // Calculate the target size maintaining aspect ratio
    private Vector2 CalculateTargetSize(Rect sourceRect, Rect targetRect)
    {
        float aspectRatio = sourceRect.width / (float)sourceRect.height;
        float targetAspectRatio = targetRect.width / (float)targetRect.height;

        if (aspectRatio > targetAspectRatio)
        {
            return new Vector2(targetRect.width, targetRect.width / aspectRatio);
        }
        else
        {
            return new Vector2(targetRect.height * aspectRatio, targetRect.height);
        }
    }

    // Method to resize a texture
    private Texture2D ResizeTexture(Texture2D texture, int newWidth, int newHeight)
    {
        Texture2D resizedTexture = new Texture2D(newWidth, newHeight);
        Rect sourceRect = new Rect(0, 0, texture.width, texture.height);
        Rect targetRect = new Rect(0, 0, newWidth, newHeight);
        
        for (int y = 0; y < newHeight; y++)
        {
            for (int x = 0; x < newWidth; x++)
            {
                float sourceX = x / (float)newWidth * texture.width;
                float sourceY = y / (float)newHeight * texture.height;
                
                resizedTexture.SetPixel(x, y, texture.GetPixel((int)sourceX, (int)sourceY));
            }
        }
        resizedTexture.Apply();
        return resizedTexture;
    }
}