// 代码生成时间: 2025-08-02 18:39:06
using System;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Network connection status checker class.
/// </summary>
public class NetworkStatusChecker : MonoBehaviour
{
    /// <summary>
    /// Check the network connection status.
    /// </summary>
    public void CheckNetworkStatus()
    {
        try
        {
            // Use Ping to check if we can reach a known server
            Ping pingSender = new Ping(pingHost);
            PingReply reply = pingSender.SendPing();

            // Check the reply status
            if (reply.Status == IPStatus.Success)
            {
                Debug.Log("Network connection is active. Ping latency: " + reply.RoundTripTime + "ms");
            }
            else
            {
                Debug.LogError("Network connection issue detected. Status: " + reply.Status);
            }
        }
        catch (PingException e)
        {
            Debug.LogError("Ping failed with error: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred while checking network status: " + e.Message);
        }
    }

    /// <summary>
    /// The host to ping for network status check.
    /// </summary>
    private string pingHost = "www.google.com";

    // Start is called before the first frame update
    void Start()
    {
        CheckNetworkStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Add code to periodically check network status
    }
}
