// 代码生成时间: 2025-08-05 23:07:08
// MessageNotificationSystem.cs
// This class represents a simple message notification system in Unity using C#.

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple message notification system that allows for dispatching and handling of messages.
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    // A dictionary to hold the message subscribers
    private Dictionary<string, List<Action<string>>> subscribers = new Dictionary<string, List<Action<string>>>();

    /// <summary>
    /// Subscribes a callback to a specific message type.
    /// </summary>
    /// <param name="messageType">The type of message to subscribe to.</param>
    /// <param name="callback">The callback to invoke when a message of the specified type is received.</param>
    public void Subscribe(string messageType, Action<string> callback)
    {
        if (!subscribers.ContainsKey(messageType))
            subscribers[messageType] = new List<Action<string>>();

        subscribers[messageType].Add(callback);
    }

    /// <summary>
    /// Unsubscribes a callback from a specific message type.
    /// </summary>
    /// <param name="messageType">The type of message to unsubscribe from.</param>
    /// <param name="callback">The callback to remove.</param>
    public void Unsubscribe(string messageType, Action<string> callback)
    {
        if (subscribers.ContainsKey(messageType))
        {
            subscribers[messageType].Remove(callback);

            if (subscribers[messageType].Count == 0)
                subscribers.Remove(messageType);
        }
    }

    /// <summary>
    /// Dispatches a message to all subscribers of the specified type.
    /// </summary>
    /// <param name="messageType">The type of message to dispatch.</param>
    /// <param name="message">The actual message to send.</param>
    public void DispatchMessage(string messageType, string message)
    {
        if (subscribers.ContainsKey(messageType))
        {
            foreach (Action<string> callback in subscribers[messageType])
            {
                try
                {
                    callback.Invoke(message);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error dispatching message: {ex.Message}");
                }
            }
        }
    }
}
