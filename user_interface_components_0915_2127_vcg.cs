// 代码生成时间: 2025-09-15 21:27:12
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents a library of user interface components.
/// </summary>
public class UserInterfaceComponents
{
    private Dictionary<string, GameObject> _uiComponents;

    /// <summary>
    /// Initializes a new instance of the UserInterfaceComponents class.
    /// </summary>
    public UserInterfaceComponents()
    {
        _uiComponents = new Dictionary<string, GameObject>();
    }

    /// <summary>
    /// Registers a UI component by its name and the actual GameObject.
    /// </summary>
    /// <param name="name">The name of the UI component.</param>
    /// <param name="component">The GameObject representing the UI component.</param>
    public void RegisterComponent(string name, GameObject component)
    {
        // Check if the component is already registered
        if (_uiComponents.ContainsKey(name))
        {
            Debug.LogError("Component with the same name already exists.");
            return;
        }

        _uiComponents.Add(name, component);
    }

    /// <summary>
    /// Retrieves a UI component by its name.
    /// </summary>
    /// <param name="name">The name of the UI component to retrieve.</param>
    /// <returns>The GameObject representing the UI component, or null if not found.</returns>
    public GameObject GetComponent(string name)
    {
        if (_uiComponents.TryGetValue(name, out GameObject component))
        {
            return component;
        }
        else
        {
            Debug.LogError("Component not found: " + name);
            return null;
        }
    }

    /// <summary>
    /// Removes a UI component from the library.
    /// </summary>
    /// <param name="name">The name of the UI component to remove.</param>
    public void RemoveComponent(string name)
    {
        if (_uiComponents.ContainsKey(name))
        {
            _uiComponents.Remove(name);
        }
        else
        {
            Debug.LogError("Component not found: " + name);
        }
    }

    /// <summary>
    /// Checks if a UI component is registered.
    /// </summary>
    /// <param name="name">The name of the UI component to check.</param>
    /// <returns>True if the component is registered, otherwise false.</returns>
    public bool HasComponent(string name)
    {
        return _uiComponents.ContainsKey(name);
    }
}
