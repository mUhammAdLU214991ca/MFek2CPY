// 代码生成时间: 2025-10-04 03:58:22
// UserPermissionManager.cs
// 该类实现了一个基本的用户权限管理系统。

using System;
using System.Collections.Generic;

// 定义一个枚举，代表用户的角色。
public enum UserRole {
    Guest,
    User,
    Admin
}

// 定义一个枚举，代表用户的权限。
public enum UserPermission {
    Read,
    Write,
    Delete
}

public class UserPermissionManager
{
    // 存储用户的权限映射。
    private Dictionary<UserRole, HashSet<UserPermission>> rolePermissionsMap;

    // 构造函数，初始化权限映射。
    public UserPermissionManager()
    {
        rolePermissionsMap = new Dictionary<UserRole, HashSet<UserPermission>>
        {
            { UserRole.Guest, new HashSet<UserPermission> { UserPermission.Read } },
            { UserRole.User, new HashSet<UserPermission> { UserPermission.Read, UserPermission.Write } },
            { UserRole.Admin, new HashSet<UserPermission> { UserPermission.Read, UserPermission.Write, UserPermission.Delete } }
        };
    }

    // 检查用户是否有特定的权限。
    public bool HasPermission(UserRole role, UserPermission permission)
    {
        if (!rolePermissionsMap.ContainsKey(role))
        {
            // 角色不存在。
            throw new ArgumentException($"Role {role} is not defined.");
        }

        return rolePermissionsMap[role].Contains(permission);
    }

    // 更新用户角色的权限。
    public void UpdateRolePermissions(UserRole role, HashSet<UserPermission> newPermissions)
    {
        if (!rolePermissionsMap.ContainsKey(role))
        {
            // 角色不存在。
            throw new ArgumentException($"Role {role} is not defined.");
        }

        rolePermissionsMap[role] = newPermissions;
    }

    // 获取用户角色的所有权限。
    public HashSet<UserPermission> GetPermissionsByRole(UserRole role)
    {
        if (!rolePermissionsMap.ContainsKey(role))
        {
            // 角色不存在。
            throw new ArgumentException($"Role {role} is not defined.");
        }

        return new HashSet<UserPermission>(rolePermissionsMap[role]);
    }
}
