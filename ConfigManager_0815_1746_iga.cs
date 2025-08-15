// 代码生成时间: 2025-08-15 17:46:07
using System;
using System.IO;
using UnityEngine;

// ConfigManager类用于管理应用程序的配置文件。
public class ConfigManager
{
    private const string ConfigPath = "config.txt";

    // 加载配置文件
    public string LoadConfig()
    {
        try
        {
            if (File.Exists(ConfigPath))
            {
                return File.ReadAllText(ConfigPath);
            }
            else
            {
                Debug.LogError("配置文件不存在");
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("加载配置文件时发生错误: " + e.Message);
            return null;
        }
    }

    // 保存配置文件
    public void SaveConfig(string configData)
    {
        try
        {
            File.WriteAllText(ConfigPath, configData);
            Debug.Log("配置文件已保存");
        }
        catch (Exception e)
        {
            Debug.LogError("保存配置文件时发生错误: " + e.Message);
        }
    }

    // 更新配置文件中的特定设置
    public bool UpdateConfigSetting(string key, string value)
    {
        try
        {
            string configData = LoadConfig();
            if (!string.IsNullOrEmpty(configData))
            {
                // 假设配置文件是键值对格式，用换行符分隔
                string[] lines = configData.Split('
');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith(key + "="))
                    {
                        lines[i] = key + "=" + value;
                        break;
                    }
                }
                SaveConfig(string.Join("
", lines));
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            Debug.LogError("更新配置设置时发生错误: " + e.Message);
            return false;
        }
    }
}
