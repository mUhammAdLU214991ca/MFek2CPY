// 代码生成时间: 2025-08-11 13:55:47
using System;
using UnityEngine;

/// <summary>
/// Represents an access control system for Unity applications.
/// </summary>
public class AccessControl
{
    private string[] allowedUsers;
    private string[] restrictedAreas;

    /// <summary>
    /// Initializes a new instance of the AccessControl class.
    /// </summary>
    /// <param name="allowedUsers">List of users allowed access.</param>
    /// <param name="restrictedAreas">List of areas restricted to certain users.</param>
    public AccessControl(string[] allowedUsers, string[] restrictedAreas)
    {
        this.allowedUsers = allowedUsers;
        this.restrictedAreas = restrictedAreas;
    }

    /// <summary>
    /// Checks if a user has access to a particular area.
    /// </summary>
    /// <param name="username">The username of the user attempting access.</param>
    /// <param name="area">The area the user is trying to access.</param>
    /// <returns>Returns true if the user has access, false otherwise.</returns>
    public bool HasAccess(string username, string area)
    {
        // Check if the user is allowed
        if (Array.IndexOf(allowedUsers, username) == -1)
        {
            Debug.LogError($"Access denied for user: {username}. User is not allowed.");
            return false;
        }

        // Check if the area is restricted and if the user has access
        if (Array.IndexOf(restrictedAreas, area) != -1)
        {
            // If the area is restricted, check if the user is in the allowed list
            if (Array.IndexOf(allowedUsers, username) == -1)
            {
                Debug.LogError($"Access denied for user: {username}. Restricted area: {area}.");
                return false;
            }
            else
            {
                // User is in allowed list, grant access
                Debug.Log($"Access granted for user: {username}.");
                return true;
            }
        }
        else
        {
            // Area is not restricted, grant access
            Debug.Log($"Access granted for user: {username}. Area: {area} is not restricted.");
            return true;
        }
    }

    /// <summary>
    /// Adds a user to the allowed list.
    /// </summary>
    /// <param name="username">The username to add.</param>
    public void AddUser(string username)
    {
        if (!allowedUsers.Contains(username))
        {
            allowedUsers = allowedUsers.Append(username).ToArray();
            Debug.Log($"User added to allowed list: {username}.");
        }
        else
        {
            Debug.LogWarning($"User already exists in allowed list: {username}.");
        }
    }

    /// <summary>
    /// Adds a restricted area.
    /// </summary>
    /// <param name="area">The area to restrict.</param>
    public void AddRestrictedArea(string area)
    {
        if (!restrictedAreas.Contains(area))
        {
            restrictedAreas = restrictedAreas.Append(area).ToArray();
            Debug.Log($"Area added to restricted list: {area}.");
        }
        else
        {
            Debug.LogWarning($"Area already exists in restricted list: {area}.");
        }
    }
}
