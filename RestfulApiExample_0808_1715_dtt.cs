// 代码生成时间: 2025-08-08 17:15:14
using System;
using BestHTTP;
using BestHTTP.WebSocket;
using UnityEngine;
using UnityEngine.Networking;

public class RestfulApiExample : MonoBehaviour
{
    // Base URL for the API
    private string baseUrl = "http://your-api-url.com/api/";

    private void Start()
    {
        // Register for BestHTTP events
        BestHTTP.GlobalEvent.GetEvent<HTTPEventBase>().RegisterOnAllEvents(OnRequestFinished);
    }

    private void OnDestroy()
    {
        // Unregister from BestHTTP events
        BestHTTP.GlobalEvent.GetEvent<HTTPEventBase>().UnregisterOnAllEvents(OnRequestFinished);
    }

    // Call this method to get a resource from the API
    public void GetResource(string resourcePath, Action<string> onSuccess, Action<string> onError)
    {
        // Create a new HTTP Request
        using (var request = new HTTPRequest(new Uri(baseUrl + resourcePath), OnGetResponse, OnGetError))
        {
            // Set the request method to GET
            request.Method = HTTPMethods.GET;

            // Send the request
            request.Send();
        }
    }

    // Called when a GET request finishes
    private void OnGetResponse(HTTPRequest req, HTTPResponse resp)
    {
        // Check if the request was successful
        if (resp.IsSuccess)
        {
            // Call the onSuccess callback with the response text
            onSuccess?.Invoke(resp.DataAsText);
        }
        else
        {
            // Call the onError callback with the error message
            onError?.Invoke("Error: " + resp.ErrorException.Message);
        }
    }

    // Called when a GET request fails
    private void OnGetError(HTTPRequest req, Exception ex)
    {
        // Log the error and call the onError callback
        Debug.LogError("HTTP Error: " + ex.Message);
        onError?.Invoke("HTTP Error: " + ex.Message);
    }

    // Called when a BestHTTP event occurs
    private void OnRequestFinished(HTTPRequest req, HTTPResponse resp)
    {
        // Handle events for all types of requests here
    }
}
