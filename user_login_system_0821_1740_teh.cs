// 代码生成时间: 2025-08-21 17:40:12
using System;
using UnityEngine;
using System.Collections.Generic;

// 用户登录验证系统
public class UserLoginSystem
{
    // 用户信息的存储
    private Dictionary<string, string> users = new Dictionary<string, string>();

    // 向系统添加用户
    public void AddUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogError("Username or password cannot be null or empty.");
            return;
        }

        if (users.ContainsKey(username))
        {
            Debug.LogError("User already exists.");
            return;
        }

        users.Add(username, password);
        Debug.Log("User added successfully.");
    }

    // 用户登录验证
    public bool Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogError("Username or password cannot be null or empty.");
            return false;
        }

        if (users.TryGetValue(username, out string storedPassword) && storedPassword == password)
        {
            Debug.Log("User logged in successfully.");
            return true;
        }
        else
        {
            Debug.LogError("Invalid username or password.");
            return false;
        }
    }

    // 启动时加载用户信息
    private void Start()
    {
        // 模拟用户信息加载过程
        AddUser("user1", "password1");
        AddUser("user2", "password2");
    }

    // 更新函数，用于处理登录请求
    private void Update()
    {
        // 这里可以添加登录请求的逻辑
        // 例如，从UI获取用户名和密码，然后调用Login方法
    }
}
