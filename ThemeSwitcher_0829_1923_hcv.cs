// 代码生成时间: 2025-08-29 19:23:12
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ThemeSwitcher class handles theme switching functionality in a Unity application.
/// </summary>
public class ThemeSwitcher : MonoBehaviour
{
    /// <summary>
    /// Reference to the Theme Manager which contains the themes and their colors.
    /// </summary>
    public ThemeManager themeManager;

    /// <summary>
    /// Reference to the UI component that will display the current theme color.
    /// </summary>
    public Image themePreview;

    /// <summary>
    /// Call this method to switch to the next theme in the list.
    /// </summary>
    public void SwitchTheme()
    {
        try
        {
            if (themeManager == null)
            {
                Debug.LogError("ThemeManager is not assigned.");
                return;
            }

            // Get the next theme index and wrap around if necessary.
            int nextThemeIndex = (themeManager.CurrentThemeIndex + 1) % themeManager.Themes.Count;

            // Set the new theme.
            themeManager.SetTheme(nextThemeIndex);

            // Update the preview image color to the new theme color.
            if (themePreview != null)
                themePreview.color = themeManager.Themes[themeManager.CurrentThemeIndex].Color;

            Debug.Log($"Theme switched to: {themeManager.Themes[themeManager.CurrentThemeIndex].Name}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error switching theme: {ex.Message}");
        }
    }
}

/// <summary>
/// ThemeManager class manages the list of themes and provides functionality to switch themes.
/// </summary>
[System.Serializable]
public class ThemeManager
{
    /// <summary>
    /// List of themes available for switching.
    /// </summary>
    public List<Theme> Themes;

    /// <summary>
    /// The currently active theme index.
    /// </summary>
    public int CurrentThemeIndex = 0;

    /// <summary>
    /// Sets the active theme by index.
    /// </summary>
    /// <param name="themeIndex">The index of the theme to set.</param>
    public void SetTheme(int themeIndex)
    {
        if (Themes == null || themeIndex < 0 || themeIndex >= Themes.Count)
        {
            Debug.LogError("Invalid theme index.");
            return;
        }

        CurrentThemeIndex = themeIndex;
    }
}

/// <summary>
/// Theme class represents a single theme with a name and a color.
/// </summary>
[System.Serializable]
public class Theme
{
    /// <summary>
    /// The name of the theme.
    /// </summary>
    public string Name;

    /// <summary>
    /// The color associated with the theme.
    /// </summary>
    public Color Color;
}
