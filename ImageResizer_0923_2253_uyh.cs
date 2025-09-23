// 代码生成时间: 2025-09-23 22:53:58
 * 作者：[Your Name]
 * 日期：[Today's Date]
 */
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageResizer : MonoBehaviour
{
    // 目标图片文件夹路径
    public string targetFolderPath = "Path/To/Your/Images";
    // 目标图片尺寸
    public Vector2Int targetSize = new Vector2Int(256, 256);
    // 图片格式
    public TextureFormat textureFormat = TextureFormat.RGBA32;

    // 调整图片尺寸
    public void ResizeImages()
    {
        try
        {
            // 获取目标文件夹内所有图片
            string[] files = Directory.GetFiles(targetFolderPath);
            foreach (string file in files)
            {
                // 检查文件扩展名是否为图片格式
                if (Path.GetExtension(file).ToLower() == ".png" || Path.GetExtension(file).ToLower() == ".jpg")
                {
                    // 加载图片
                    Texture2D texture = LoadTexture(file);

                    if (texture != null)
                    {
                        // 创建新的Texture2D对象
                        Texture2D resizedTexture = new Texture2D(targetSize.x, targetSize.y, textureFormat, false);

                        // 调整图片尺寸
                        ResizeTexture(texture, resizedTexture);

                        // 保存调整后的图片
                        SaveTexture(resizedTexture, file);
                    }
                }
            }
            Debug.Log("图片尺寸调整完成");
        }
        catch (Exception ex)
        {
            Debug.LogError("发生错误：" + ex.Message);
        }
    }

    // 加载图片
    private Texture2D LoadTexture(string filePath)
    {
        try
        {
            return TextureLoader.LoadImageAtPath<Texture2D>(filePath);
        }
        catch (Exception ex)
        {
            Debug.LogError("加载图片失败：" + ex.Message);
            return null;
        }
    }

    // 调整图片尺寸
    private void ResizeTexture(Texture2D sourceTexture, Texture2D resizedTexture)
    {
        // 创建RenderTexture对象
        RenderTexture renderTexture = new RenderTexture(resizedTexture.width, resizedTexture.height, 0);

        // 设置RenderTexture为当前渲染目标
        RenderTexture.active = renderTexture;

        // 绘制原始图片到RenderTexture
        Graphics.Blit(sourceTexture, renderTexture);

        // 读取RenderTexture的像素数据
        Texture2DReader textureReader = new Texture2DReader(renderTexture);
        resizedTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        resizedTexture.Apply();

        // 释放RenderTexture对象
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(renderTexture);
    }

    // 保存图片
    private void SaveTexture(Texture2D texture, string filePath)
    {
        string directory = Path.GetDirectoryName(filePath);
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);
        string savePath = Path.Combine(directory, fileName + "_resized" + extension);

        // 保存图片到指定路径
        File.WriteAllBytes(savePath, texture.EncodeToPNG());
    }
}
