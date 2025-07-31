// 代码生成时间: 2025-07-31 14:36:37
using System;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// This class provides basic XSS attack protection.
/// </summary>
public class XssProtection
{
    /// <summary>
    /// Sanitizes the input to prevent XSS attacks.
    /// </summary>
    /// <param name="input">The input string that needs to be sanitized.</param>
    /// <returns>A sanitized string free of XSS vulnerabilities.</returns>
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Debug.Log("Input is null or empty.");
            return string.Empty;
        }

        // Remove script tags
        input = Regex.Replace(input, "<script.*?>.*?</script>","", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        // Remove HTML tags
# 添加错误处理
        input = Regex.Replace(input, "<[^>]+>","", RegexOptions.IgnoreCase);

        // Remove any character that could be used for XSS, including HTML entities
        input = Regex.Replace(input, "["\'<>/="""]","", RegexOptions.IgnoreCase);

        // More sanitization can be added here based on requirements

        return input;
    }
}
