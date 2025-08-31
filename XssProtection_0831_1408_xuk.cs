// 代码生成时间: 2025-08-31 14:08:36
using System;
using UnityEngine;
using System.Text.RegularExpressions;

/// <summary>
/// Class responsible for protecting against XSS attacks.
/// </summary>
public class XssProtection
{
    /// <summary>
    /// Sanitizes a string to prevent XSS attacks by removing or encoding potential script tags.
    /// </summary>
    /// <param name="input">The string to sanitize.</param>
    /// <returns>The sanitized string.</returns>
    public string SanitizeString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            // Return empty string if input is null or empty
            return "";
        }

        // Use Regex to replace any HTML tags with their corresponding HTML entities
        string sanitizedInput = Regex.Replace(input, "<[^>]*>?", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        // Replace any remaining script-related tags with their entities
        sanitizedInput = Regex.Replace(sanitizedInput, @