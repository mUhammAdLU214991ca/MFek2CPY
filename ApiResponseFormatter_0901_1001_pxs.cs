// 代码生成时间: 2025-09-01 10:01:33
using System;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// A utility class for formatting API responses.
/// </summary>
public static class ApiResponseFormatter
{
    /// <summary>
    /// Formats the API response as a JSON string.
    /// </summary>
    /// <typeparam name="T">The type of the response object.</typeparam>
    /// <param name="response">The response object to format.</param>
    /// <param name="prettyPrint">Whether to format the JSON with indentation.</param>
    /// <returns>The formatted JSON string.</returns>
    public static string FormatResponse<T>(T response, bool prettyPrint = false)
    {
        try
        {
            var settings = prettyPrint ? new JsonSerializerSettings { Formatting = Formatting.Indented } : new JsonSerializerSettings();
            return JsonConvert.SerializeObject(response, settings);
        }
        catch (Exception ex)
        {
            // Log the exception and return a formatted error message
            Debug.LogError($"Error formatting API response: {ex.Message}");
            return FormatErrorResponse(ex);
        }
    }

    /// <summary>
    /// Formats an error response as a JSON string.
    /// </summary>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>The formatted error response JSON string.</returns>
    private static string FormatErrorResponse(Exception ex)
    {
        // Define the structure of the error response
        var errorResponse = new
        {
            success = false,
            message = ex.Message,
            errorCode = ex.HResult
        };

        // Serialize the error response to JSON
        return JsonConvert.SerializeObject(errorResponse, Formatting.Indented);
    }
}
