// 代码生成时间: 2025-09-04 06:02:07
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
# 扩展功能模块

/// <summary>
/// 响应式布局控制器，用于适应不同的屏幕尺寸和分辨率
/// </summary>
public class ResponsiveLayout : MonoBehaviour
{
    private Camera mainCamera;
    private RectTransform canvasRectTransform;
# TODO: 优化性能
    private float defaultScreenWidth = 1920f; // 默认屏幕宽度
    private float defaultScreenHeight = 1080f; // 默认屏幕高度

    /// <summary>
    /// 启动时调用，设置响应式布局
    /// </summary>
    void Start()
# 优化算法效率
    {
        mainCamera = Camera.main;
        canvasRectTransform = GetComponent<RectTransform>();
# 添加错误处理
        ApplyResponsiveLayout();
    }
# 优化算法效率

    /// <summary>
    /// 应用响应式布局
    /// </summary>
# 增强安全性
    private void ApplyResponsiveLayout()
    {
        // 获取当前屏幕宽高与默认宽高的比例
        float screenRatio = (float)Screen.width / Screen.height;
        float defaultRatio = defaultScreenWidth / defaultScreenHeight;

        // 根据屏幕宽高比调整Canvas大小
# NOTE: 重要实现细节
        if (screenRatio > defaultRatio)
        {
            // 横屏模式
            canvasRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
                canvasRectTransform.rect.width * (Screen.height / defaultScreenHeight));
            canvasRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,
                canvasRectTransform.rect.height * (Screen.width / defaultScreenWidth));
        }
# 优化算法效率
        else
        {
            // 竖屏模式
            canvasRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
                canvasRectTransform.rect.width * (Screen.width / defaultScreenWidth));
            canvasRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,
                canvasRectTransform.rect.height * (Screen.height / defaultScreenHeight));
        }
    }

    /// <summary>
# 添加错误处理
    /// 屏幕大小改变时调用，更新响应式布局
    /// </summary>
    void OnRectTransformDimensionsChange()
    {
        ApplyResponsiveLayout();
    }
}
