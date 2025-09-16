// 代码生成时间: 2025-09-16 10:48:49
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// 进程管理器，用于管理和操作系统进程。
/// </summary>
public class ProcessManager : MonoBehaviour
{
    // 私有变量，存储进程列表
    private Process[] _processes;

    /// <summary>
    /// 启动进程管理器。
    /// </summary>
    private void Start()
    {
        InitializeProcessList();
    }

    /// <summary>
    /// 初始化进程列表。
    /// </summary>
    private void InitializeProcessList()
    {
        try
        {
            // 获取当前系统的所有进程
            _processes = Process.GetProcesses();
        }
        catch (Exception ex)
        {
            Debug.LogError("Error initializing process list: " + ex.Message);
        }
    }

    /// <summary>
    /// 获取所有进程的名称。
    /// </summary>
    /// <returns>进程名称的数组。</returns>
    public string[] GetAllProcessNames()
    {
        if (_processes == null)
        {
            Debug.LogError("Process list is not initialized.");
            return null;
        }

        string[] processNames = new string[_processes.Length];
        for (int i = 0; i < _processes.Length; i++)
        {
            processNames[i] = _processes[i].ProcessName;
        }

        return processNames;
    }

    /// <summary>
    /// 根据进程名称找到进程ID。
    /// </summary>
    /// <param name="processName">进程名称。</param>
    /// <returns>进程ID。</returns>
    public int? GetProcessIdByName(string processName)
    {
        if (_processes == null)
        {
            Debug.LogError("Process list is not initialized.");
            return null;
        }

        foreach (var process in _processes)
        {
            if (process.ProcessName == processName)
            {
                return process.Id;
            }
        }

        Debug.Log("Process not found: " + processName);
        return null;
    }

    /// <summary>
    /// 终止指定ID的进程。
    /// </summary>
    /// <param name="processId">进程ID。</param>
    /// <returns>是否成功终止进程。</returns>
    public bool TerminateProcessById(int processId)
    {
        try
        {
            foreach (var process in _processes)
            {
                if (process.Id == processId)
                {
                    process.Kill();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error terminating process: " + ex.Message);
        }

        return false;
    }
}
