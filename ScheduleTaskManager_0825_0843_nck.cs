// 代码生成时间: 2025-08-25 08:43:48
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// 定时任务调度器类
public class ScheduleTaskManager
{
    // 存储所有的定时任务
    private readonly List<Timer> _timers;

    // 构造函数
    public ScheduleTaskManager()
    {
        _timers = new List<Timer>();
    }

    // 添加定时任务
    public void AddTimer(Action action, float interval, bool repeat)
    {
        try
        {
            // 创建一个新的计时器并添加到列表中
            Timer timer = new Timer(
                callback: action,
                state: null,
                dueTime: TimeSpan.FromSeconds(0), // 立即执行
                period: TimeSpan.FromSeconds(interval) // 间隔时间
            );

            _timers.Add(timer);

            if (!repeat)
            {
                // 如果不重复，执行一次后自动取消
                timer.Change(TimeSpan.FromMilliseconds(int.MaxValue), TimeSpan.FromMilliseconds(int.MaxValue));
            }
            else
            {
                // 如果重复，立即启动计时器
                timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(interval));
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error adding timer: {ex.Message}");
        }
    }

    // 取消所有定时任务
    public void CancelAllTimers()
    {
        foreach (var timer in _timers)
        {
            timer.Dispose();
        }
        _timers.Clear();
    }

    // 更新方法，用于Unity框架中的MonoBehaviour
    private void Update()
    {
        // 检查并移除已经完成的计时器
        _timers.RemoveAll(timer => timer.Disposed);
    }
}

// 计时器类
public class Timer : IDisposable
{
    // 计时器方法
    private readonly TimerCallback _callback;
    // 计时器状态
    private readonly object _state;
    // 计时器句柄
    private readonly System.Threading.Timer _timer;
    // 计时器是否已销毁
    public bool Disposed { get; private set; }

    public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
    {
        _callback = callback;
        _state = state;
        _timer = new System.Threading.Timer(ExecuteCallback, _state, dueTime, period);
    }

    private void ExecuteCallback(object state)
    {
        _callback(state);
    }

    public void Dispose()
    {
        _timer.Dispose();
        Disposed = true;
    }
}
