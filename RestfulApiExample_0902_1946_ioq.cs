// 代码生成时间: 2025-09-02 19:46:39
 * This is a simple RESTful API example in C# for Unity that provides endpoints for a hypothetical resource.
 * It demonstrates clear structure, error handling, comments, and best practices.
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Define a class for the hypothetical resource.
[Serializable]
public class Resource {
    public int id;
    public string name;
}

// Define a RESTful API controller class.
public class RestfulApiExample : MonoBehaviour {
    private const string ApiBaseUrl = "http://example.com/api/resources";

    // GET /api/resources - Retrieves a list of resources.
    public IEnumerator GetResources(Action<List<Resource>> onSuccess, Action<UnityWebRequest> onError) {
        string url = ApiBaseUrl;
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.timeout = 10;

        // Send the request and wait for the response.
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError) {
            onError?.Invoke(request);
        } else {
            // Parse the response to the expected object format.
            List<Resource> resources = JsonUtility.FromJson<List<Resource>>(request.downloadHandler.text);
            onSuccess?.Invoke(resources);
        }
    }

    // POST /api/resources - Creates a new resource.
    public IEnumerator CreateResource(Resource resource, Action<Resource> onSuccess, Action<UnityWebRequest> onError) {
        string url = ApiBaseUrl;
        string json = JsonUtility.ToJson(resource);
        UnityWebRequest request = UnityWebRequest.Post(url, json);
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 10;

        // Send the request and wait for the response.
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError) {
            onError?.Invoke(request);
        } else {
            // Parse the response to the expected object format.
            Resource createdResource = JsonUtility.FromJson<Resource>(request.downloadHandler.text);
            onSuccess?.Invoke(createdResource);
        }
    }

    // Additional methods for PUT and DELETE could be added here following a similar pattern.

    // Utility method to handle errors gracefully.
    private void HandleError(UnityWebRequest request) {
        Debug.LogError("Error Code: " + request.responseCode + "; Error Message: " + request.error);
    }
}
