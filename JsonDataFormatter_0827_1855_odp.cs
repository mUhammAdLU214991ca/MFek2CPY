// 代码生成时间: 2025-08-27 18:55:42
// JsonDataFormatter.cs
// 这个类负责将JSON数据格式进行转换。

using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; // 用于处理JSON数据

public class JsonDataFormatter
{
    // 将JSON字符串转换为C#对象
    public static T ConvertJsonToType<T>(string json) where T : class
    {
        try
        {
            // 尝试将JSON字符串解析为指定的C#对象类型
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (JsonException e)
        {
            // 如果解析失败，输出错误信息
            Debug.LogError("JSON解析错误: " + e.Message);
            return null;
        }
    }

    // 将C#对象转换为JSON字符串
    public static string ConvertTypeToJson<T>(T obj) where T : class
    {
        try
        {
            // 将C#对象序列化为JSON字符串
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        catch (Exception e)
        {
            // 如果序列化失败，输出错误信息
            Debug.LogError("JSON序列化错误: " + e.Message);
            return null;
        }
    }

    // 示例：使用类
    // 假设有一个简单的User类用于测试
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // 主入口点
    public static void Main(string[] args)
    {
        try
        {
            // 创建一个User对象
            User user = new User() { Name = "John Doe", Age = 30 };

            // 将User对象转换为JSON字符串
            string jsonString = ConvertTypeToJson(user);
            Debug.Log("JSON Output: " + jsonString);

            // 将JSON字符串转换回User对象
            User deserializedUser = ConvertJsonToType<User>(jsonString);
            Debug.Log("Deserialized User Name: " + deserializedUser.Name + ", Age: " + deserializedUser.Age);
        }
        catch (Exception e)
        {
            // 捕获任何未处理的异常
            Debug.LogError("未处理异常: " + e.Message);
        }
    }
}