// 代码生成时间: 2025-09-02 13:29:09
using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ApiResponseFormatter
{
    // Formats the API response to a standardized format
    public static string FormatApiResponse(string jsonResponse)
    {
        try
        {
            // Deserialize the JSON response into a JObject
            var responseJson = JObject.Parse(jsonResponse);

            // Extract and format the response data
            var formattedResponse = FormatResponseData(responseJson);

            // Return the formatted response as JSON string
            return JsonConvert.SerializeObject(formattedResponse, Formatting.Indented);
        }
        catch (JsonException ex)
        {
            // Handle JSON parsing errors
            Debug.LogError($"Error parsing JSON: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Handle any other unexpected errors
            Debug.LogError($"An error occurred: {ex.Message}");
            return null;
        }
    }

    // Formats the response data into a standardized object
    private static JObject FormatResponseData(JObject responseJson)
    {
        // Create a new JObject to hold the formatted response
        JObject formattedResponse = new JObject();

        // Add a status flag indicating success or failure
        formattedResponse["success"] = responseJson["success"] ?? false;

        // Add the actual response data
        formattedResponse["data"] = responseJson["data"];

        // Add error details if any
        if (responseJson["error"] != null)
        {
            formattedResponse["error"] = responseJson["error"].ToString();
        }

        // Add any additional metadata if needed
        formattedResponse["metadata"] = responseJson["metadata"] ?? new JObject();

        return formattedResponse;
    }
}
