// 代码生成时间: 2025-09-21 23:01:24
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponsiveLayout : MonoBehaviour
{
    /// <summary>
    /// The RectTransform component of the layout canvas.
    /// </summary>
    public RectTransform canvasRectTransform;

    /// <summary>
    /// The list of elements to adjust for responsiveness.
    /// </summary>
    public List<RectTransform> elementsToAdjust;

    /// <summary>
    /// The spacing between elements.
    /// </summary>
    public float spacing;

    private void Start()
    {
        AdjustLayout();
    }

    /// <summary>
    /// Adjusts the layout based on the current screen size and orientation.
    /// </summary>
    private void AdjustLayout()
    {
        if (canvasRectTransform == null)
        {
            Debug.LogError("Canvas RectTransform not set.");
            return;
        }

        // Calculate the available width and height based on the canvas size.
        float availableWidth = canvasRectTransform.rect.width;
        float availableHeight = canvasRectTransform.rect.height;

        // Adjust each element's position and size.
        foreach (RectTransform element in elementsToAdjust)
        {
            try
            {
                // Set the element's size based on the available space.
                element.sizeDelta = new Vector2(availableWidth, element.sizeDelta.y);

                // Adjust the position based on the previous element and spacing.
                if (elementsToAdjust.IndexOf(element) > 0)
                {
                    RectTransform previousElement = elementsToAdjust[elementsToAdjust.IndexOf(element) - 1];
                    element.anchoredPosition = new Vector2(0, previousElement.anchoredPosition.y - previousElement.sizeDelta.y - spacing);
                }
                else
                {
                    element.anchoredPosition = Vector2.zero;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error adjusting {element.name}: {e.Message}");
            }
        }
    }

    /// <summary>
    /// Call this method to re-adjust the layout if needed, for example, after a screen resize.
    /// </summary>
    public void RecalculateLayout()
    {
        AdjustLayout();
    }
}
