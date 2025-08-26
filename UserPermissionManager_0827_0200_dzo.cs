// 代码生成时间: 2025-08-27 02:00:45
using System;
using System.Collections.Generic;

/// <summary>
/// A simple user permission management system for Unity using C#.
/// </summary>
public class UserPermissionManager
{
    private Dictionary<string, HashSet<string>> userPermissions;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserPermissionManager"/> class.
    /// </summary>
    public UserPermissionManager()
    {
        userPermissions = new Dictionary<string, HashSet<string>>();
    }

    /// <summary>
    /// Adds a permission to a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="permission">The permission to add.</param>
    public void AddPermission(string userId, string permission)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
        }

        if (string.IsNullOrEmpty(permission))
        {
            throw new ArgumentException("Permission cannot be null or empty.", nameof(permission));
        }

        if (!userPermissions.ContainsKey(userId))
        {
            userPermissions[userId] = new HashSet<string>();
        }

        userPermissions[userId].Add(permission);
    }

    /// <summary>
    /// Removes a permission from a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="permission">The permission to remove.</param>
    public void RemovePermission(string userId, string permission)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
        }

        if (string.IsNullOrEmpty(permission))
        {
            throw new ArgumentException("Permission cannot be null or empty.", nameof(permission));
        }

        if (userPermissions.ContainsKey(userId))
        {
            userPermissions[userId].Remove(permission);
            if (userPermissions[userId].Count == 0)
            {
                userPermissions.Remove(userId);
            }
        }
    }

    /// <summary>
    /// Checks if a user has a specific permission.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="permission">The permission to check.</param>
    /// <returns>True if the user has the permission, otherwise false.</returns>
    public bool HasPermission(string userId, string permission)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
        }

        if (string.IsNullOrEmpty(permission))
        {
            throw new ArgumentException("Permission cannot be null or empty.", nameof(permission));
        }

        return userPermissions.ContainsKey(userId) && userPermissions[userId].Contains(permission);
    }

    /// <summary>
    /// Gets all permissions for a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A list of permissions for the user.</returns>
    public List<string> GetPermissions(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
        }

        if (userPermissions.ContainsKey(userId))
        {
            return new List<string>(userPermissions[userId]);
        }
        else
        {
            return new List<string>();
        }
    }
}
