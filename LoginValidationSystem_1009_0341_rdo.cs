// 代码生成时间: 2025-10-09 03:41:21
using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 登录验证系统
/// </summary>
public class LoginValidationSystem : MonoBehaviour
{
    /// <summary>
    /// 用户信息字典，模拟数据库
    /// </summary>
    private Dictionary<string, string> userDatabase = new Dictionary<string, string>()
    {
        { "user1", "password1" },
        { "user2", "password2" }
    };

    /// <summary>
    /// 登录验证方法
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>登录成功返回true，否则返回false</returns>
    public bool ValidateLogin(string username, string password)
    {
        try
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Debug.LogError("用户名或密码不能为空");
                return false;
            }

            // 检查用户是否存在
            if (!userDatabase.ContainsKey(username))
            {
                Debug.LogError("用户不存在");
                return false;
            }

            // 验证密码
            if (userDatabase[username] != password)
            {
                Debug.LogError("密码错误");
                return false;
            }

            // 登录成功
            Debug.Log("登录成功");
            return true;
        }
        catch (Exception ex)
        {
            // 错误处理
            Debug.LogError("登录验证异常: " + ex.Message);
            return false;
        }
    }

    // 在Unity编辑器中测试时调用的方法
    private void Start()
    {
        // 测试登录
        TestLogin();
    }

    /// <summary>
    /// 测试登录验证系统
    /// </summary>
    private void TestLogin()
    {
        // 测试数据
        string testUsername = "user1";
        string testPassword = "password1";

        // 执行登录验证
        bool loginResult = ValidateLogin(testUsername, testPassword);

        // 打印测试结果
        if (loginResult)
        {
            Debug.Log("测试登录成功");
        }
        else
        {
            Debug.Log("测试登录失败");
        }
    }
}