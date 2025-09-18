// 代码生成时间: 2025-09-18 17:38:35
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 表单数据验证器
/// </summary>
public class FormValidator
{
    /// <summary>
    /// 验证表单数据
    /// </summary>
    /// <param name="formData">表单数据</param>
    /// <returns>验证结果</returns>
    public List<string> ValidateFormData(Dictionary<string, string> formData)
    {
        List<string> errors = new List<string>();

        if (formData == null)
        {
            throw new ArgumentNullException(nameof(formData), "表单数据不能为空");
        }

        // 验证用户名
        if (!ValidateUsername(formData["username"]))
        {
            errors.Add("用户名无效");
        }

        // 验证邮箱
        if (!ValidateEmail(formData["email"]))
        {
            errors.Add("邮箱无效");
        }

        // 验证密码
        if (!ValidatePassword(formData["password"]))
        {
            errors.Add("密码无效");
        }

        return errors;
    }

    /// <summary>
    /// 验证用户名
    /// </summary>
    /// <param name="username">用户名</param>
    /// <returns>是否有效</returns>
    private bool ValidateUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return false;
        }

        return username.Length >= 3 && username.Length <= 20;
    }

    /// <summary>
    /// 验证邮箱
    /// </summary>
    /// <param name="email">邮箱</param>
    /// <returns>是否有效</returns>
    private bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 验证密码
    /// </summary>
    /// <param name="password">密码</param>
    /// <returns>是否有效</returns>
    private bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }

        return password.Length >= 8;
    }
}
