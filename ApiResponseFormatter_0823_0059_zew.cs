// 代码生成时间: 2025-08-23 00:59:07
using System;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// An API response formatter tool that can format API responses
/// into a structured format.
/// </summary>
public class ApiResponseFormatter
{
    /// <summary>
    /// Formats an API response into a JSON formatted string.
    /// </summary>
    /// <param name="response">The response object from the API.</param>
    /// <returns>A JSON formatted string representing the API response.</returns>
    public string FormatResponse(object response)
    {
        try
        {
            // Serialize the response object to a JSON string.
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            return jsonResponse;
        }
        catch (Exception ex)
        {
            // Handle any serialization errors gracefully.
            Debug.LogError($"Error formatting response: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Parses a JSON formatted string into an object.
    /// </summary>
    /// <typeparam name="T">The type of object to parse the JSON into.</typeparam>
    /// <param name="json">The JSON formatted string to parse.</param>
    /// <returns>The object representation of the JSON string.</returns>
    public T ParseJson<T>(string json)
    {
        try
        {
            // Deserialize the JSON string into the specified type.
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            // Handle any deserialization errors gracefully.
            Debug.LogError($"Error parsing JSON: {ex.Message}");
            return default(T);
        }
    }
}
