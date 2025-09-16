// 代码生成时间: 2025-09-17 00:58:48
using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 消息通知系统类
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    // 消息订阅者列表
    private List<MessageSubscriber> subscribers = new List<MessageSubscriber>();

    /// <summary>
    /// 订阅消息
    /// </summary>
    /// <param name="subscriber">订阅者</param>
    public void Subscribe(MessageSubscriber subscriber)
    {
        if (subscriber == null)
        {
            Debug.LogError("订阅者不能为null");
            return;
        }

        if (!subscribers.Contains(subscriber))
        {
            subscribers.Add(subscriber);
        }
    }

    /// <summary>
    /// 取消订阅消息
    /// </summary>
    /// <param name="subscriber">订阅者</param>
    public void Unsubscribe(MessageSubscriber subscriber)
    {
        if (subscriber == null)
        {
            Debug.LogError("订阅者不能为null");
            return;
        }

        subscribers.Remove(subscriber);
    }

    /// <summary>
    /// 发送消息给所有订阅者
    /// </summary>
    /// <param name="message">消息内容</param>
    public void Notify(string message)
    {
        foreach (var subscriber in subscribers)
        {
            try
            {
                subscriber.ReceiveMessage(message);
            }
            catch (Exception ex)
            {
                Debug.LogError("发送消息时发生错误: " + ex.Message);
            }
        }
    }
}

/// <summary>
/// 消息订阅者抽象类
/// </summary>
public abstract class MessageSubscriber
{
    /// <summary>
    /// 接收消息
    /// </summary>
    /// <param name="message">消息内容</param>
    public abstract void ReceiveMessage(string message);
}
