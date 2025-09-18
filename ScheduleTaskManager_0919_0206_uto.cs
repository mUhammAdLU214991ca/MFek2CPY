// 代码生成时间: 2025-09-19 02:06:03
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// 定时任务调度器
/// </summary>
public class ScheduleTaskManager
{
    private Dictionary<string, Timer> timers = new Dictionary<string, Timer>();
    private object lockObject = new object();

    /// <summary>
    /// 启动定时任务
    /// </summary>
    /// <param name="taskName">任务名称</param>
    /// <param name="interval">执行间隔时间（毫秒）</param>
    /// <param name="action">定时执行的委托</param>
    public void StartTask(string taskName, int interval, Action action)
    {
        if (string.IsNullOrEmpty(taskName))
        {
            Debug.LogError("Task name cannot be null or empty.");
            return;
        }

        if (interval <= 0)
        {
            Debug.LogError("Interval must be greater than zero.");
            return;
        }

        if (action == null)
        {
            Debug.LogError("Action cannot be null.");
            return;
        }

        lock (lockObject)
        {
            if (timers.ContainsKey(taskName))
            {
                Debug.LogWarning($"Task {taskName} is already running.");
                return;
            }

            var timer = new Timer(state =>
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error occurred in task {taskName}: {ex.Message}");
                }
            }, null, interval, interval);

            timers.Add(taskName, timer);
            Debug.Log($"Task {taskName} started with interval {interval} ms.");
        }
    }

    /// <summary>
    /// 停止定时任务
    /// </summary>
    /// <param name="taskName">任务名称</param>
    public void StopTask(string taskName)
    {
        lock (lockObject)
        {
            if (!timers.ContainsKey(taskName))
            {
                Debug.LogWarning($"Task {taskName} is not running.");
                return;
            }

            timers[taskName].Dispose();
            timers.Remove(taskName);
            Debug.Log($"Task {taskName} stopped.");
        }
    }

    /// <summary>
    /// 停止所有定时任务
    /// </summary>
    public void StopAllTasks()
    {
        lock (lockObject)
        {
            foreach (var timer in timers.Values)
            {
                timer.Dispose();
            }

            timers.Clear();
            Debug.Log("All tasks stopped.");
        }
    }
}
