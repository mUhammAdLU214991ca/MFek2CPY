// 代码生成时间: 2025-10-04 20:08:47
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// 富文本编辑器类，用于处理文本输入和格式设置。
/// </summary>
public class RichTextEditor : MonoBehaviour
{
    // 文本输入框
    public InputField inputField;
    // 显示富文本的文本组件
    public Text outputText;
    // 用于存储格式命令的字典
    private Dictionary<string, System.Action<string>> formatCommands;

    // 初始化方法，设置格式命令
    private void Start()
    {
        formatCommands = new Dictionary<string, System.Action<string>>
        {
            { "bold", text => text.Bold() },
            { "italic", text => text.Italic() },
            // 可以根据需要添加更多的格式命令
        };
    }

    // 更新富文本显示的方法
    public void UpdateRichText(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            outputText.text = "";
            return;
        }

        // 这里简单地将输入文本中的特定命令替换为富文本格式
        string richText = ApplyFormatCommands(input);
        outputText.text = richText;
    }

    // 应用格式命令到文本
    private string ApplyFormatCommands(string input)
    {
        foreach (var command in formatCommands)
        {
            string openTag = $"<{command.Key}>";
            string closeTag = $"</{command.Key}>";
            input = input.Replace(openTag, $"<color=yellow>{openTag}</color>")
                       .Replace(closeTag, $"</color>{closeTag}");
        }

        return input;
    }

    // 格式化文本的方法，这里以加粗为例
    private string Bold(string text)
    {
        return $"<b>{text}</b>";
    }

    // 格式化文本的方法，这里以斜体为例
    private string Italic(string text)
    {
        return $"<i>{text}</i>";
    }
}

// 扩展方法，用于给字符串添加格式
public static class StringExtensions
{
    public static string Bold(this string text)
    {
        return $"<b>{text}</b>";
    }

    public static string Italic(this string text)
    {
        return $"<i>{text}</i>";
    }

    // 可以根据需要添加更多的扩展方法
}