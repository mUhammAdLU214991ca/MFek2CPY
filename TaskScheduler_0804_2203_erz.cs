// 代码生成时间: 2025-08-04 22:03:21
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// 定时任务调度器
public class TaskScheduler
{
    private readonly List<ScheduledTask> tasks;
    private bool isRunning;
    private readonly int updateInterval; // 更新间隔时间(毫秒)

    // 构造函数
    public TaskScheduler(int updateInterval = 1000)
    {
        this.updateInterval = updateInterval;
        tasks = new List<ScheduledTask>();
        isRunning = false;
    }

    // 添加定时任务
    public void AddTask(Action action, int interval, int repeatCount = -1)
    {
        tasks.Add(new ScheduledTask(action, interval, repeatCount));
    }

    // 启动定时任务调度器
    public void Start()
    {
        if (isRunning)
        {
            Debug.LogError("Scheduler is already running.");
            return;
        }

        isRunning = true;
        Thread thread = new Thread(Run);
        thread.Start();
    }

    // 停止定时任务调度器
    public void Stop()
    {
        isRunning = false;
    }

    // 运行定时任务调度器
    private void Run()
    {
        while (isRunning)
        {
            foreach (var task in tasks)
            {
                if (task.ShouldRun())
                {
                    try
                    {
                        task.Action.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Error executing task: {ex.Message}");
                    }
                }
            }
            Thread.Sleep(updateInterval);
        }
    }
}

// 定时任务类
public class ScheduledTask
{
    public Action Action { get; }
    public int Interval { get; }
    public int RepeatCount { get; }
    public int ExecutionCount { get; private set; }

    public ScheduledTask(Action action, int interval, int repeatCount)
    {
        Action = action;
        Interval = interval;
        RepeatCount = repeatCount;
    }

    // 检查是否应该执行任务
    public bool ShouldRun()
    {
        if (RepeatCount == -1 || ExecutionCount < RepeatCount)
        {
            ExecutionCount++;
            return true;
        }
        return false;
    }
}
