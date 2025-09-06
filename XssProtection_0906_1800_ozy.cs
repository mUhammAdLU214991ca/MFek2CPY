// 代码生成时间: 2025-09-06 18:00:38
using System;
using System.Text.RegularExpressions;
using UnityEngine;

// 功能：提供XSS攻击防护的类
public class XssProtection
{
    private static readonly Regex scriptPattern = new Regex("<script>.*?</script>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex scriptEndTagPattern = new Regex("</script", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex scriptStartTagPattern = new Regex("<script", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex eventPattern = new Regex("(on\w+\s*=\s*["'][^"']*["'])", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    // 清除输入字符串中的XSS攻击代码
    public static string SanitizeInput(string input)
    {
        try
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // 移除所有<script>标签
            input = scriptPattern.Replace(input, "");
            input = scriptEndTagPattern.Replace(input, "");
            input = scriptStartTagPattern.Replace(input, "");

            // 移除所有事件属性，如onclick, onerror等
            input = eventPattern.Replace(input, "");

            return input;
        }
        catch (Exception e)
        {
            Debug.LogError("Error sanitizing input: " + e.Message);
            return null;
        }
    }

    // 主函数，用于测试XSS防护功能
    public static void Main(string[] args)
    {
        string userInput = "<script>alert('XSS')</script>";
        string sanitizedInput = SanitizeInput(userInput);
        Debug.Log("User Input: " + userInput + "
Sanitized Input: " + sanitizedInput);
    }
}
