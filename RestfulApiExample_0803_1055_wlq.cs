// 代码生成时间: 2025-08-03 10:55:56
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

/// <summary>
/// RESTful API接口的示例实现。
/// </summary>
public class RestfulApiExample
{
    private string baseUrl = "http://api.example.com/"; // API的基础URL，根据实际情况替换为实际API的URL

    /// <summary>
    /// 获取资源列表。
    /// </summary>
    /// <typeparam name="T">资源的类型。</typeparam>
    /// <param name="resourcePath">API路径。</param>
    /// <param name="resultCallback">成功回调函数。</param>
    /// <param name="errorCallback">错误回调函数。</param>
    public void GetResources<T>(string resourcePath, Action<List<T>> resultCallback, Action<string> errorCallback)
    {
        // 构建完整的API URL
        string url = baseUrl + resourcePath;

        // 发起GET请求
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SendWebRequest().completed += operation =>
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                // 处理错误情况
                errorCallback?.Invoke("Error: " + request.error);
            }
            else
            {
                // 反序列化响应数据
                List<T> resources = JsonUtility.FromJson<List<T>>(request.downloadHandler.text);
                resultCallback?.Invoke(resources);
            }
        };
    }

    /// <summary>
    /// 创建新资源。
    /// </summary>
    /// <typeparam name="T">资源的类型。</typeparam>
    /// <param name="resourcePath">API路径。</param>
    /// <param name="resource">要创建的资源。</param>
    /// <param name="resultCallback">成功回调函数。</param>
    /// <param name="errorCallback">错误回调函数。</param>
    public void CreateResource<T>(string resourcePath, T resource, Action<T> resultCallback, Action<string> errorCallback)
    {
        // 构建完整的API URL
        string url = baseUrl + resourcePath;

        // 序列化对象为JSON
        string json = JsonUtility.ToJson(resource);

        // 发起POST请求
        UnityWebRequest request = UnityWebRequest.Post(url, json);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest().completed += operation =>
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                // 处理错误情况
                errorCallback?.Invoke("Error: " + request.error);
            }
            else
            {
                // 反序列化响应数据
                T createdResource = JsonUtility.FromJson<T>(request.downloadHandler.text);
                resultCallback?.Invoke(createdResource);
            }
        };
    }

    // 可以根据需要添加更多的API方法，如UpdateResource和DeleteResource等。
}