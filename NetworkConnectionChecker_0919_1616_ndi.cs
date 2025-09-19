// 代码生成时间: 2025-09-19 16:16:44
// <summary>
// A Unity component used to check network connection status.
// </summary>
using System;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkConnectionChecker : MonoBehaviour
{
    private bool isCheckingConnection;
    private bool isConnected;
    private string connectionCheckUrl;
    private float checkInterval = 10.0f; // In seconds
    private float nextCheckTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        connectionCheckUrl = "http://example.com"; // You can replace with a real URL
        isCheckingConnection = false;
        isConnected = true; // Default assumption
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCheckingConnection && Time.time > nextCheckTime)
        {
            CheckConnection();
        }
    }

    // Checks the network connection status
    private void CheckConnection()
    {
        try
        {
            UnityWebRequest request = UnityWebRequest.Get(connectionCheckUrl);
            request.timeout = 10; // Timeout in seconds
            request.SendWebRequest().ContinueWith(result =>
            {
                if (result.IsCompleted)
                {
                    if (result.Result.isNetworkError || result.Result.isHttpError)
                    {
                        if (isConnected)
                        {
                            Debug.LogError("Network connection lost.");
                            isConnected = false;
                        }
                    }
                    else
                    {
                        if (!isConnected)
                        {
                            Debug.Log("Network connection re-established.");
                            isConnected = true;
                        }
                    }
                    isCheckingConnection = false;
                }
                else
                {
                    Debug.LogError("Network connection check failed: " + result.Exception.Message);
                    isCheckingConnection = false;
                }
            });
            isCheckingConnection = true;
            nextCheckTime = Time.time + checkInterval;
        }
        catch (Exception e)
        {
            Debug.LogError("Error during network connection check: " + e.Message);
            isCheckingConnection = false;
        }
    }

    // Public accessor for the connection status
    public bool IsConnected
    {
        get { return isConnected; }
    }
}
