// 代码生成时间: 2025-08-18 11:37:37
using System;
using System.IO;
using System.IO.Compression;

/// <summary>
/// A tool for decompressing files in Unity.
/// </summary>
public class FileDecompressor
{
    /// <summary>
    /// Decompresses a ZIP file to a specified directory.
    /// </summary>
    /// <param name="zipFilePath">The path to the ZIP file.</param>
    /// <param name="outputDirectory">The directory to extract the contents to.</param>
    /// <returns>True if decompression is successful, otherwise false.</returns>
    public static bool DecompressZipFile(string zipFilePath, string outputDirectory)
    {
        try
        {
            // Validate input arguments.
            if (string.IsNullOrEmpty(zipFilePath) || string.IsNullOrEmpty(outputDirectory))
            {
                throw new ArgumentException("Zip file path and output directory cannot be null or empty.");
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDirectory);

            // Decompress the ZIP file.
            ZipFile.ExtractToDirectory(zipFilePath, outputDirectory);

            Console.WriteLine("Decompression successful.");
            return true;
        }
        catch (Exception ex)
        {
            // Handle exceptions and log errors.
            Console.WriteLine($"An error occurred during decompression: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Main method for testing the decompression tool.
    /// </summary>
    public static void Main(string[] args)
    {
        // Example usage of the DecompressZipFile method.
        // Replace these paths with actual file paths for testing.
        string zipFilePath = "path_to_zip_file.zip";
        string outputDirectory = "path_to_output_directory";

        bool result = DecompressZipFile(zipFilePath, outputDirectory);

        if (result)
        {
            Console.WriteLine("The file has been successfully decompressed.");
        }
        else
        {
            Console.WriteLine("Decompression failed.");
        }
    }
}
