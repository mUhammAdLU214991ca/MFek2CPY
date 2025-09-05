// 代码生成时间: 2025-09-05 08:43:35
using System;
using UnityEngine;

/// <summary>
/// Notification System manages messaging in the application.
/// </summary>
public class NotificationSystem : MonoBehaviour
{
    private static NotificationSystem instance;

    /// <summary>
    /// Gets the singleton instance of the NotificationSystem.
    /// </summary>
    public static NotificationSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NotificationSystem>();
                if (instance == null)
                {
                    GameObject notificationSystemObject = new GameObject("NotificationSystem");
                    instance = notificationSystemObject.AddComponent<NotificationSystem>();
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Delegate for notification event handlers.
    /// </summary>
    /// <param name="message">The message to be notified.</param>
    public delegate void NotificationHandler(string message);

    /// <summary>
    /// Event that subscribers can listen to for receiving notifications.
    /// </summary>
    public event NotificationHandler OnNotification;

    /// <summary>
    /// Sends a notification to all subscribers.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    public void Notify(string message)
    {
        try
        {
            OnNotification?.Invoke(message);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error in Notify method: " + ex.Message);
        }
    }

    /// <summary>
    /// Subscribes to the notification event.
    /// </summary>
    /// <param name="handler">The event handler to subscribe with.</param>
    public void Subscribe(NotificationHandler handler)
    {
        if (handler != null)
        {
            OnNotification += handler;
        }
    }

    /// <summary>
    /// Unsubscribes from the notification event.
    /// </summary>
    /// <param name="handler">The event handler to unsubscribe.</param>
    public void Unsubscribe(NotificationHandler handler)
    {
        if (handler != null)
        {
            OnNotification -= handler;
        }
    }

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("A second instance of NotificationSystem found. Destroying it!");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
