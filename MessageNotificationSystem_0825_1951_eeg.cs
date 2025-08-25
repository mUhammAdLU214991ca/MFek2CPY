// 代码生成时间: 2025-08-25 19:51:17
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消息通知系统
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    private static MessageNotificationSystem _instance;
    private List<Message> messageQueue = new List<Message>();

    // 消息事件
    public delegate void MessageEventHandler(Message message);
    public static event MessageEventHandler OnMessageReceived;

    private void Awake()
    {
        // 单例模式
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // 处理消息队列
        if (messageQueue.Count > 0)
        {
            foreach (var message in messageQueue)
            {
                ProcessMessage(message);
            }
            messageQueue.Clear();
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="message"></param>
    public void SendMessage(Message message)
    {
        if (message == null)
        {
            Debug.LogError("SendMessage: Message is null");
            return;
        }

        messageQueue.Add(message);
    }

    /// <summary>
    /// 处理消息
    /// </summary>
    /// <param name="message"></param>
    private void ProcessMessage(Message message)
    {
        try
        {
            // 调用消息事件
            OnMessageReceived?.Invoke(message);
        }
        catch (Exception ex)
        {
            Debug.LogError($"ProcessMessage: Error processing message - {ex.Message}");
        }
    }
}

/// <summary>
/// 消息类
/// </summary>
public class Message
{
    public string Content { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }

    public Message(string content, string sender, string receiver)
    {
        Content = content;
        Sender = sender;
        Receiver = receiver;
    }
}
