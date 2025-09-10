// 代码生成时间: 2025-09-10 14:37:11
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

// 网页内容抓取工具类
public class WebContentGrabber
{
    private readonly HttpClient _httpClient;

    public WebContentGrabber()
    {
        // 创建HttpClient实例，用于网络请求
        _httpClient = new HttpClient();
    }

    // 异步方法，抓取网页内容
    public async Task<string> FetchWebContentAsync(string url)
    {
        try
        {
            // 发送GET请求到指定的URL
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // 读取响应内容
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        catch (HttpRequestException e)
        {
            // 处理HTTP请求异常
            Console.WriteLine("Error fetching web content: " + e.Message);
            return null;
        }
        catch (Exception e)
        {
            // 处理其他异常
            Console.WriteLine("An error occurred: " + e.Message);
            return null;
        }
    }

    // 同步方法，抓取网页内容
    public string FetchWebContent(string url)
    {
        try
        {
            // 发送GET请求到指定的URL
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            // 读取响应内容
            string content = response.Content.ReadAsStringAsync().Result;
            return content;
        }
        catch (AggregateException e)
        {
            // 处理HTTP请求异常
            Console.WriteLine("Error fetching web content: " + e.InnerException.Message);
            return null;
        }
        catch (Exception e)
        {
            // 处理其他异常
            Console.WriteLine("An error occurred: " + e.Message);
            return null;
        }
    }

    // 主函数，用于演示抓取工具的使用
    public static void Main(string[] args)
    {
        WebContentGrabber grabber = new WebContentGrabber();
        string url = "https://www.example.com";

        // 异步抓取网页内容
        string contentAsync = grabber.FetchWebContentAsync(url).Result;
        Console.WriteLine("Async fetched content: " + contentAsync);

        // 同步抓取网页内容
        string contentSync = grabber.FetchWebContent(url);
        Console.WriteLine("Sync fetched content: " + contentSync);
    }
}