// 代码生成时间: 2025-08-12 22:47:00
using System;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// Provides functionality to prevent XSS (Cross-Site Scripting) attacks.
/// </summary>
public class XssProtection : MonoBehaviour
{
    /// <summary>
    /// Sanitizes input to prevent XSS attacks.
    /// </summary>
    /// <param name="input">The input string that needs to be sanitized.</param>
    /// <returns>The sanitized string free from XSS vulnerabilities.</returns>
    public string SanitizeInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            // Return an empty string if input is null or empty.
            return "";
        }

        // Remove all HTML tags to prevent script injection.
        string safeInput = Regex.Replace(input, "<[^>]*>