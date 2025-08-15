// 代码生成时间: 2025-08-15 08:15:42
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// A Unity utility class for scraping web content.
/// </summary>
public class WebContentScraper
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="WebContentScraper"/> class.
    /// </summary>
    public WebContentScraper()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Asynchronously fetches the content of a webpage and returns it as a string.
    /// </summary>
    /// <param name="url">The URL of the webpage to scrape.</param>
    /// <returns>A task that contains the webpage content as a string.</returns>
    public async Task<string> FetchWebContentAsync(string url)
    {
        try
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            await webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error fetching content from {url}: {webRequest.error}");
                return null;
            }

            return webRequest.downloadHandler.text;
        }
        catch (Exception e)
        {
            Debug.LogError($"An error occurred while fetching content: {e.Message}");
            return null;
        }
    }

    /// <summary>
    /// Extracts specific content from the webpage using a regular expression.
    /// </summary>
    /// <param name="webContent">The content of the webpage.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>A list of matches found in the webpage content.</returns>
    public List<string> ExtractContentUsingRegex(string webContent, string pattern)
    {
        List<string> matches = new List<string>();
        Regex regex = new Regex(pattern);
        MatchCollection matchesCollection = regex.Matches(webContent);

        foreach (Match match in matchesCollection)
        {
            matches.Add(match.Value);
        }

        return matches;
    }

    /// <summary>
    /// Example usage:
    /// </summary>
    public void ExampleUsage()
    {
        string url = "https://example.com";
        string pattern = "your-regex-pattern-here";
        string webContent = FetchWebContentAsync(url).Result;

        if (webContent != null)
        {
            List<string> extractedContent = ExtractContentUsingRegex(webContent, pattern);
            foreach (var content in extractedContent)
            {
                Debug.Log(content);
            }
        }
    }
}
