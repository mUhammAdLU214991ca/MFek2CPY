// 代码生成时间: 2025-08-10 02:01:57
using System;
# 扩展功能模块
using UnityEngine;
using System.Collections.Generic;

/// <summary>
# 优化算法效率
/// MessageNotificationSystem is a simple notification system that allows components to subscribe to and receive messages.
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    private static MessageNotificationSystem _instance;
    public static MessageNotificationSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find the instance in the scene
                GameObject notificationManager = GameObject.FindWithTag("NotificationManager");
# 优化算法效率
                if (notificationManager != null)
                {
                    _instance = notificationManager.GetComponent<MessageNotificationSystem>();
# TODO: 优化性能
                }
                else
                {
                    // Create a new NotificationManager if none exist
                    notificationManager = new GameObject("NotificationManager");
# NOTE: 重要实现细节
                    _instance = notificationManager.AddComponent<MessageNotificationSystem>();
                }
            }
            return _instance;
        }
    }

    private Dictionary<string, List<Action<string>>> subscribers = new Dictionary<string, List<Action<string>]];

    /// <summary>
    /// Subscribe to a message channel.
    /// </summary>
    /// <param name="channel">The channel to subscribe to.</param>
    /// <param name="action">The action to be called when a message is received on this channel.</param>
    public void Subscribe(string channel, Action<string> action)
    {
        if (!subscribers.ContainsKey(channel))
# 扩展功能模块
        {
            subscribers[channel] = new List<Action<string>>();
# NOTE: 重要实现细节
        }

        subscribers[channel].Add(action);
    }
# NOTE: 重要实现细节

    /// <summary>
# NOTE: 重要实现细节
    /// Unsubscribe from a message channel.
    /// </summary>
    /// <param name="channel">The channel to unsubscribe from.</param>
    /// <param name="action">The action to be removed from the channel.</param>
    public void Unsubscribe(string channel, Action<string> action)
    {
        if (subscribers.ContainsKey(channel))
        {
# TODO: 优化性能
            subscribers[channel].Remove(action);

            if (subscribers[channel].Count == 0)
            {
                subscribers.Remove(channel);
            }
        }
    }

    /// <summary>
# 扩展功能模块
    /// Publish a message to a channel.
    /// </summary>
# 增强安全性
    /// <param name="channel">The channel to publish the message to.</param>
    /// <param name="message">The message to publish.</param>
    public void Publish(string channel, string message)
# 增强安全性
    {
        if (subscribers.ContainsKey(channel))
        {
# NOTE: 重要实现细节
            foreach (var action in subscribers[channel])
            {
                try
                {
                    action(message);
                }
                catch (Exception e)
# 改进用户体验
                {
                    Debug.LogError($"Error publishing message to {channel}: {e.Message}");
# 添加错误处理
                }
            }
        }
    }

    // Ensure the instance is not destroyed on scene load
# FIXME: 处理边界情况
    void Awake()
    {
        if (_instance == null)
        {
# 增强安全性
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
