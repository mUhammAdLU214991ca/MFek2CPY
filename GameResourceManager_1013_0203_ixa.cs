// 代码生成时间: 2025-10-13 02:03:32
using System.Collections;
using UnityEngine;

public class GameResourceManager : MonoBehaviour
{
    /// <summary>
    /// Dictionary to hold the loaded resources for quick access.
    /// </summary>
    private Dictionary<string, GameObject> loadedResources = new Dictionary<string, GameObject>();

    /// <summary>
    /// Loads a resource and adds it to the loadedResources dictionary.
    /// </summary>
    /// <param name="resourceName">The name of the resource to load.</param>
    /// <returns>The loaded resource as a GameObject.</returns>
    public GameObject LoadResource(string resourceName)
    {
        if (string.IsNullOrEmpty(resourceName))
        {
            Debug.LogError("Resource name cannot be null or empty.");
            return null;
        }

        GameObject resource;

        if (loadedResources.TryGetValue(resourceName, out resource))
        {
            // Resource is already loaded, return the instance.
            return resource;
        }
        else
        {
            // Resource is not loaded, attempt to load it.
            resource = Resources.Load<GameObject>(resourceName);
            if (resource == null)
            {
                Debug.LogError($"Failed to load resource: {resourceName}");
                return null;
            }

            // Add the loaded resource to the dictionary.
            loadedResources.Add(resourceName, resource);
            return resource;
        }
    }

    /// <summary>
    /// Unloads a resource from the loadedResources dictionary and from memory.
    /// </summary>
    /// <param name="resourceName">The name of the resource to unload.</param>
    public void UnloadResource(string resourceName)
    {
        if (string.IsNullOrEmpty(resourceName))
        {
            Debug.LogError("Resource name cannot be null or empty.");
            return;
        }

        GameObject resource;

        if (loadedResources.TryGetValue(resourceName, out resource))
        {
            // Resource is found, destroy it to free memory.
            Destroy(resource);
            loadedResources.Remove(resourceName);
        }
        else
        {
            Debug.LogError($"Resource not found in loadedResources: {resourceName}");
        }
    }

    /// <summary>
    /// Clears all loaded resources from memory.
    /// </summary>
    public void ClearAllResources()
    {
        foreach (var resource in loadedResources.Values)
        {
            Destroy(resource);
        }
        loadedResources.Clear();
    }

    // Ensure to call this method when the game ends or before loading a new scene
    // to free up resources and avoid memory leaks.
    private void OnDestroy()
    {
        ClearAllResources();
    }
}
