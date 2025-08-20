// 代码生成时间: 2025-08-20 20:40:46
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Configuration file manager for Unity projects.
/// </summary>
public class ConfigFileManager
{
    private const string ConfigFolder = "Config/";
    private const string ConfigExtension = ".cfg";
    private string configPath;

    /// <summary>
    /// Initializes a new instance of the ConfigFileManager class.
    /// </summary>
    /// <param name="configName">The name of the configuration file.</param>
    public ConfigFileManager(string configName)
    {
        configPath = Path.Combine(ConfigFolder, configName + ConfigExtension);
    }

    /// <summary>
    /// Loads the configuration from the file.
    /// </summary>
    /// <returns>The configuration data as a dictionary.</returns>
    public Dictionary<string, string> LoadConfig()
    {
        if (!File.Exists(configPath))
        {
            Debug.LogError("Configuration file not found: " + configPath);
            return null;
        }

        try
        {
            string[] lines = File.ReadAllLines(configPath);
            Dictionary<string, string> configData = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                string[] keyValue = line.Split('=');
                if (keyValue.Length == 2)
                {
                    configData[keyValue[0].Trim()] = keyValue[1].Trim();
                }
                else
                {
                    Debug.LogWarning("Invalid line in config file: " + line);
                }
            }

            return configData;
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to load config file: " + ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Saves the configuration to the file.
    /// </summary>
    /// <param name="configData">The configuration data to save.</param>
    public void SaveConfig(Dictionary<string, string> configData)
    {
        if (configData == null)
        {
            Debug.LogError("Configuration data is null, cannot save to file.");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(configPath))
            {
                foreach (KeyValuePair<string, string> entry in configData)
                {
                    writer.WriteLine(entry.Key + "=" + entry.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to save config file: " + ex.Message);
        }
    }
}
