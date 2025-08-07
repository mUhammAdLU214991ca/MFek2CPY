// 代码生成时间: 2025-08-07 18:04:47
using UnityEngine;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

/// <summary>
/// NetworkConnectionStatusChecker is a utility class that checks the network connection status.
/// </summary>
public class NetworkConnectionStatusChecker : MonoBehaviour
{
    private const string LogFormat = "Network Status: {0}";

    private void Start()
    {
        // Schedule the network check to run once a minute.
        InvokeRepeating("CheckNetworkStatus", 0f, 60f);
    }

    /// <summary>
    /// Checks the network connection status asynchronously.
    /// </summary>
    private void CheckNetworkStatus()
    {
        try
        {
            bool isConnected = IsNetworkConnected();
            Debug.LogFormat(LogFormat, isConnected ? "Connected" : "Disconnected");
        }
        catch (System.Exception ex)
        {
            Debug.LogErrorFormat("An error occurred while checking network status: {0}", ex.Message);
        }
    }

    /// <summary>
    /// Determines if the network connection is active.
    /// </summary>
    /// <returns>True if connected, false otherwise.</returns>
    private bool IsNetworkConnected()
    {
        // Check if the system is connected to a network.
        return NetworkInterface.GetIsNetworkAvailable();
    }
}
