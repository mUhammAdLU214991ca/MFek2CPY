// 代码生成时间: 2025-09-03 18:00:44
// ResponsiveLayout.cs
// This script is designed to handle responsive layout changes in Unity based on screen size.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResponsiveLayout : MonoBehaviour
{
    public RectTransform contentPanel; // RectTransform to adjust the size and position based on screen aspect ratio.
    public float preferredWidth = 1280f; // Preferred width for layout.
    public float preferredHeight = 720f; // Preferred height for layout.
    public Vector2 minSize = new Vector2(480f, 270f); // Minimum size for the layout.
    public Vector2 maxSize = new Vector2(2560f, 1440f); // Maximum size for the layout.
    public bool maintainAspectRatio = true; // Whether to maintain the aspect ratio of the preferred size.

    private void Start()
    {
        ApplyLayout();
    }

    // Call this method to reapply the layout when needed, for example, when the screen size changes.
    public void ApplyLayout()
    {
        if (contentPanel == null)
        {
            Debug.LogError("Content panel is not assigned. Please assign a RectTransform in the inspector.");
            return;
        }

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float screenAspectRatio = screenWidth / screenHeight;
        float preferredAspectRatio = preferredWidth / preferredHeight;

        float layoutWidth, layoutHeight;

        if (maintainAspectRatio)
        {
            if (screenAspectRatio > preferredAspectRatio)
            {
                // Screen is wider than preferred aspect ratio.
                layoutHeight = screenHeight;
                layoutWidth = layoutHeight * preferredAspectRatio;
            }
            else
            {
                // Screen is taller than preferred aspect ratio.
                layoutWidth = screenWidth;
                layoutHeight = layoutWidth / preferredAspectRatio;
            }
        }
        else
        {
            layoutWidth = screenWidth;
            layoutHeight = screenHeight;
        }

        // Clamp the layout size to min and max sizes.
        layoutWidth = Mathf.Clamp(layoutWidth, minSize.x, maxSize.x);
        layoutHeight = Mathf.Clamp(layoutHeight, minSize.y, maxSize.y);

        // Apply the calculated size to the content panel.
        contentPanel.sizeDelta = new Vector2(layoutWidth, layoutHeight);

        // Adjust the position based on the screen size.
        contentPanel.anchoredPosition = new Vector2((screenWidth - layoutWidth) / 2, (screenHeight - layoutHeight) / 2);
    }
}
