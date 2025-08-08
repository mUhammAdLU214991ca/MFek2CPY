// 代码生成时间: 2025-08-08 08:43:43
using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Security
{
    /// <summary>
    /// A utility class to protect against Cross-Site Scripting (XSS) attacks.
    /// </summary>
    public static class XssProtection
    {
        /// <summary>
        /// Sanitizes the input string to prevent XSS attacks.
        /// </summary>
        /// <param name="input">The input string to be sanitized.</param>
        /// <returns>A sanitized string that is safe to display.</returns>
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                // Return empty string if input is null or empty
                return string.Empty;
            }

            // This Regex will remove any HTML tags and JavaScript event handlers
            // which are commonly used in XSS attacks.
            // It also removes any script tags which can contain malicious scripts.
            string sanitizedInput = Regex.Replace(input, "<[^>]*>|(on[^\s]+?=.*?["'])", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            // Additional sanitization can be added here as needed.
            // For example, removing null characters which can be used in attacks.
            sanitizedInput = sanitizedInput.Replace("\u0000", "");

            return sanitizedInput;
        }
    }
}
