// 代码生成时间: 2025-09-30 19:51:40
using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

/// <summary>
/// DNS解析和缓存工具
/// </summary>
public class DNSResolverCacheTool
{
    private Dictionary<string, IPAddress> cache = new Dictionary<string, IPAddress>();
    private readonly object cacheLock = new object();

    /// <summary>
    /// 解析域名并缓存结果，如果已缓存则直接返回缓存结果
    /// </summary>
    /// <param name="hostName">要解析的域名</param>
    /// <returns>域名对应的IP地址</returns>
    public IPAddress ResolveHostName(string hostName)
    {
        IPAddress result;
        lock (cacheLock)
        {
            if (cache.TryGetValue(hostName, out result))
            {
                // 如果缓存中存在，则直接返回缓存结果
                return result;
            }
        }

        try
        {
            // 尝试解析域名
            result = Dns.GetHostEntry(hostName).AddressList[0];
            lock (cacheLock)
            {
                // 缓存解析结果
                cache[hostName] = result;
            }
            return result;
        }
        catch (Exception ex)
        {
            // 错误处理
            Debug.LogError($"Error resolving hostname {hostName}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// 清除缓存
    /// </summary>
    public void ClearCache()
    {
        lock (cacheLock)
        {
            cache.Clear();
        }
    }

    /// <summary>
    /// 打印所有缓存的域名和IP地址
    /// </summary>
    public void PrintCache()
    {
        lock (cacheLock)
        {
            foreach (var item in cache)
            {
                Debug.Log($"Cached Hostname: {item.Key}, IP: {item.Value}