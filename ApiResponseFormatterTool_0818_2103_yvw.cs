// 代码生成时间: 2025-08-18 21:03:05
using System;
# 扩展功能模块
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ApiResponseFormatterTool is a utility class for formatting API responses.
public class ApiResponseFormatterTool
{
    // Formats the API response into a structured, human-readable JSON object.
    // If the input is not a valid JSON, it will return an error message.
    public static string FormatApiResponse(string rawResponse)
# 优化算法效率
    {
        try
        {
            // Parse the raw response to a JObject for easy manipulation.
            JObject jsonResponse = JObject.Parse(rawResponse);

            // Check if the parse was successful.
            if (jsonResponse == null)
# 改进用户体验
            {
                return "Error: Invalid JSON input.";
            }

            // Return the formatted JSON string.
            return jsonResponse.ToString(Formatting.Indented);
# NOTE: 重要实现细节
        }
        catch (Exception ex)
        {
            // Return the error message with exception details if parsing fails.
            return $"Error: {ex.Message}";
        }
    }

    // Example usage of the FormatApiResponse method.
    [MenuItem("Tools/ApiResponseFormatterTool/FormatResponse")]
# 改进用户体验
    private static void FormatResponseMenuItem()
    {
        // Example API response string (to be replaced with actual API response).
        string exampleResponse = "{"status":"success","data":{"message":"Hello, World!"}}";

        // Format the API response and print to console.
        string formattedResponse = FormatApiResponse(exampleResponse);
        Debug.Log(formattedResponse);
    }
}
