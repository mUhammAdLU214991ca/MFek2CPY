// 代码生成时间: 2025-09-23 01:21:28
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class HashCalculator : MonoBehaviour
{
    /// <summary>
    /// Calculates the hash value of a given string input using the specified algorithm.
    /// </summary>
    /// <param name="input">The string to calculate the hash for.</param>
    /// <param name="algorithm">The hash algorithm to use (e.g., SHA256).</param>
    /// <returns>The hash value of the input string.</returns>
    public string CalculateHash(string input, HashAlgorithm algorithm = HashAlgorithm.SHA256)
    {
        try
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm.ToString()))
            {
                if (hashAlgorithm == null)
                {
                    Debug.LogError("Unsupported hash algorithm.");
                    return null;
                }

                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = hashAlgorithm.ComputeHash(inputBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                return hash;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while calculating hash: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// A list of available hash algorithms.
    /// </summary>
    public enum HashAlgorithm
    {
        SHA1,
        SHA256,
        SHA384,
        SHA512,
        MD5
    }

    // Optional: Unity Start method for demonstration purposes
    void Start()
    {
        string input = "Hello, World!";
        HashAlgorithm algorithm = HashAlgorithm.SHA256;
        string hash = CalculateHash(input, algorithm);
        Debug.Log($"Hash of '{input}' using {algorithm} is: {hash}");
    }
}
