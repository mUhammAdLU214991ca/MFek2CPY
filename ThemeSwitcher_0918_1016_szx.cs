// 代码生成时间: 2025-09-18 10:16:56
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the theme switching functionality within Unity.
/// </summary>
public class ThemeSwitcher : MonoBehaviour
{
    // A dictionary to hold color themes
    private Dictionary<string, Theme> themes = new Dictionary<string, Theme>();

    /// <summary>
    /// Initializes the theme switcher with a default theme.
    /// </summary>
    public void InitializeThemes(Theme defaultTheme)
    {
        if (defaultTheme == null)
        {
            Debug.LogError("Default theme cannot be null.");
            return;
        }

        // Add the default theme to the dictionary
        themes.Add("default", defaultTheme);
    }

    /// <summary>
    /// Switches the current theme to the specified theme.
    /// </summary>
    /// <param name="themeName">The name of the theme to switch to.</param>
    public void SwitchTheme(string themeName)
    {
        if (!themes.ContainsKey(themeName))
        {
            Debug.LogError($"Theme '{themeName}' not found.");
            return;
        }

        // Apply the theme to all UI elements
        ApplyTheme(themeName);
    }

    /// <summary>
    /// Applies the specified theme to all UI elements.
    /// </summary>
    /// <param name="themeName">The name of the theme to apply.</param>
    private void ApplyTheme(string themeName)
    {
        Theme theme = themes[themeName];
        foreach (var element in FindObjectsOfType<Graphic>())
        {
            // Apply color changes based on the theme
            element.color = theme.Color;
        }
    }

    /// <summary>
    /// Represents a color theme.
    /// </summary>
    [System.Serializable]
    public class Theme
    {
        public Color Color;
    }
}
