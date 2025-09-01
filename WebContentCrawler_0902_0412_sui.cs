// 代码生成时间: 2025-09-02 04:12:32
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// A utility class for web content crawling in Unity.
/// </summary>
public class WebContentCrawler
{
    private readonly HttpClient _httpClient;
    private readonly string _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3";

    /// <summary>
    /// Initializes a new instance of the WebContentCrawler class.
    /// </summary>
    public WebContentCrawler()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
    }

    /// <summary>
    /// Asynchronously retrieves the content of a webpage.
    /// </summary>
    /// <param name="url">The URL of the webpage to retrieve.</param>
    /// <returns>A string containing the content of the webpage.</returns>
    public async Task<string> GetWebContentAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Error fetching content from {url}: {e.Message}");
            return null;
        }
    }

    /// <summary>
    /// Extracts all text content from the provided webpage content using regular expressions.
    /// </summary>
    /// <param name="htmlContent">The content of the webpage to extract text from.</param>
    /// <returns>A string array containing all extracted text.</returns>
    public string[] ExtractTextContent(string htmlContent)
    {
        if (string.IsNullOrWhiteSpace(htmlContent))
        {
            return new string[0];
        }

        var pattern = "<[^>]*>"; // Pattern to match HTML tags
        var textOnlyHtml = Regex.Replace(htmlContent, pattern, string.Empty);
        var textBlocks = textOnlyHtml.Split(new[] { '
', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        return textBlocks;
    }

    /// <summary>
    /// Releases resources associated with this instance.
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
