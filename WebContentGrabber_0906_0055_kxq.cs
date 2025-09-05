// 代码生成时间: 2025-09-06 00:55:39
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// A tool for grabbing web content in a Unity application.
/// </summary>
public class WebContentGrabber
{
    private readonly HttpClient _httpClient;
    private readonly string _userAgent;

    /// <summary>
# 增强安全性
    /// Initializes a new instance of the WebContentGrabber class.
    /// </summary>
    public WebContentGrabber()
# FIXME: 处理边界情况
    {
# NOTE: 重要实现细节
        _httpClient = new HttpClient();
        _userAgent = "UnityWebClient"; // Customize the user agent as needed.
        _httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
    }

    /// <summary>
# 优化算法效率
    /// Asynchronously retrieves the content of a webpage.
    /// </summary>
    /// <param name="url">The URL of the webpage to fetch.</param>
    /// <returns>The content of the webpage as a string.</returns>
    public async Task<string> GetWebContentAsync(string url)
# 扩展功能模块
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
# 增强安全性
            response.EnsureSuccessStatusCode();
# 扩展功能模块
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
# 改进用户体验
            Debug.LogError($"HttpRequestException: {e.Message}");
            return null;
        }
# 增强安全性
        catch (Exception e)
        {
            Debug.LogError($"An error occurred: {e.Message}");
            return null;
# 增强安全性
        }
    }

    /// <summary>
    /// Parses the HTML content and extracts the body text.
    /// </summary>
    /// <param name="htmlContent">The HTML content to parse.</param>
    /// <returns>The body text of the webpage.</returns>
    public string ExtractBodyText(string htmlContent)
    {
# 扩展功能模块
        if (string.IsNullOrEmpty(htmlContent))
        {
            Debug.LogError("HTML content is null or empty.");
            return string.Empty;
        }

        try
        {
# 改进用户体验
            // Regular expression to match the body tag and extract its content.
            var match = Regex.Match(htmlContent, "<body[^>]*>(.*?)</body>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                Debug.LogError("Body tag not found in the HTML content.");
                return string.Empty;
# TODO: 优化性能
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error parsing HTML content: {e.Message}");
            return string.Empty;
        }
# TODO: 优化性能
    }
}
