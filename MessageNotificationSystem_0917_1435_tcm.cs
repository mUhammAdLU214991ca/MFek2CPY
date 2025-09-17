// 代码生成时间: 2025-09-17 14:35:59
using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageNotificationSystem : MonoBehaviour
{
    // A dictionary to hold the listeners for each message type
    private Dictionary<string, List<Action<string>>> listeners = new Dictionary<string, List<Action<string>]];

    private void Awake()
    {
        // Initialize the dictionary
        listeners = new Dictionary<string, List<Action<string>]];
    }
# 扩展功能模块

    // Register a listener for a specific message type
# TODO: 优化性能
    public void RegisterListener(string messageType, Action<string> listener)
# FIXME: 处理边界情况
    {
        if (!listeners.ContainsKey(messageType))
        {
# 优化算法效率
            listeners[messageType] = new List<Action<string>>();
        }
# NOTE: 重要实现细节

        listeners[messageType].Add(listener);
# TODO: 优化性能
    }

    // Unregister a listener from a specific message type
    public void UnregisterListener(string messageType, Action<string> listener)
    {
# 增强安全性
        if (listeners.ContainsKey(messageType))
        {
            listeners[messageType].Remove(listener);
        }
    }

    // Broadcast a message to all listeners of a specific message type
# 扩展功能模块
    public void BroadcastMessage(string messageType, string message)
    {
        if (listeners.ContainsKey(messageType) && listeners[messageType].Count > 0)
        {
# 优化算法效率
            foreach (var listener in listeners[messageType])
            {
                try
                {
                    listener.Invoke(message);
                }
                catch (Exception ex)
# 扩展功能模块
                {
                    Debug.LogError($"Error broadcasting message: {ex.Message}");
                }
            }
        }
    }

    // Optional: A method to clear all listeners for a specific message type
    public void ClearListeners(string messageType)
    {
        if (listeners.ContainsKey(messageType))
        {
            listeners[messageType].Clear();
        }
# FIXME: 处理边界情况
    }

    // Optional: A method to clear all listeners from all message types
    public void ClearAllListeners()
# 扩展功能模块
    {
        foreach (var messageType in listeners.Keys)
        {
            ClearListeners(messageType);
# 扩展功能模块
        }
    }

    // Optional: A method to check if there are any listeners for a specific message type
    public bool HasListeners(string messageType)
    {
        return listeners.ContainsKey(messageType) && listeners[messageType].Count > 0;
    }
}
