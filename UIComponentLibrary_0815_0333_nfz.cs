// 代码生成时间: 2025-08-15 03:33:17
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A library of user interface components for Unity.
/// </summary>
public class UIComponentLibrary : MonoBehaviour
{
    // Singleton instance
    public static UIComponentLibrary Instance { get; private set; }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Creates a UI component with a given type.
    /// </summary>
    /// <typeparam name="T">The type of UI component to create.</typeparam>
    /// <returns>The created UI component.</returns>
    public T CreateUIComponent<T>() where T : Component
    {
        GameObject prefab = Resources.Load<GameObject>(typeof(T).Name);
        if (prefab == null)
        {
            Debug.LogError($"Prefab of type {typeof(T).Name} not found in Resources.");
            return null;
        }

        GameObject instance = Instantiate(prefab);
        return instance.GetComponent<T>();
    }

    /// <summary>
    /// A helper method to find a UI component by its name.
    /// </summary>
    /// <typeparam name="T">The type of UI component to find.</typeparam>
    /// <param name="name">The name of the UI component.</param>
    /// <returns>The found UI component or null if not found.</returns>
    public T FindUIComponent<T>(string name) where T : Component
    {
        GameObject go = GameObject.Find(name);
        if (go != null)
        {
            return go.GetComponent<T>();
        }
        else
        {
            Debug.LogWarning($"UI Component with name {name} not found.");
            return null;
        }
    }

    /// <summary>
    /// Updates the text of a UI component.
    /// </summary>
    /// <param name="textComponent">The text component to update.</param>
    /// <param name="text">The new text to set.</param>
    public void UpdateText(Text textComponent, string text)
    {
        if (textComponent != null)
        {
            textComponent.text = text;
        }
        else
        {
            Debug.LogError("Text component is null.");
        }
    }

    /// <summary>
    /// Updates the color of a UI component.
    /// </summary>
    /// <param name="imageComponent">The image component to update.</param>
    /// <param name="color">The new color to set.</param>
    public void UpdateColor(Image imageComponent, Color color)
    {
        if (imageComponent != null)
        {
            imageComponent.color = color;
        }
        else
        {
            Debug.LogError("Image component is null.");
        }
    }

    // Additional methods for handling other UI components can be added here.
}
