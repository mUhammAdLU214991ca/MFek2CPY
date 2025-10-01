// 代码生成时间: 2025-10-01 20:23:46
// ThemeSwitcher.cs
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles theme switching functionality.
/// </summary>
public class ThemeSwitcher : MonoBehaviour
{
    /// <summary>
    /// The color variable that holds the theme color.
    /// </summary>
    public Color lightThemeColor = Color.white;
    public Color darkThemeColor = Color.gray;
    private Color currentThemeColor;

    /// <summary>
    /// The UI component that reflects the theme color.
    /// </summary>
    public Image themedUI;

    /// <summary>
    /// Start is called before the first frame update.
    /// Initializes the theme and sets the current color.
    /// </summary>
    void Start()
    {
        currentThemeColor = lightThemeColor; // Default to light theme
        ApplyTheme();
    }

    /// <summary>
    /// Switches the theme between light and dark.
    /// </summary>
    public void SwitchTheme()
    {
        try
        {
            if (currentThemeColor == lightThemeColor)
            {
                currentThemeColor = darkThemeColor;
            }
            else
            {
                currentThemeColor = lightThemeColor;
            }
            ApplyTheme();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error switching theme: " + ex.Message);
        }
    }

    /// <summary>
    /// Applies the current theme color to the themed UI component.
    /// </summary>
    private void ApplyTheme()
    {
        if (themedUI != null)
        {
            themedUI.color = currentThemeColor;
        }
        else
        {
            Debug.LogWarning("Themed UI component is not assigned.");
        }
    }
}
