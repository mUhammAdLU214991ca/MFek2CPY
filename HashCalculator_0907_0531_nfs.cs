// 代码生成时间: 2025-09-07 05:31:08
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace HashingTools
{
# 添加错误处理
    public class HashCalculator
    {
        // 计算MD5哈希值
        public string CalculateMD5Hash(string input)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error calculating MD5 hash: {ex.Message}");
                return null;
            }
# 添加错误处理
        }

        // 计算SHA256哈希值
# NOTE: 重要实现细节
        public string CalculateSHA256Hash(string input)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
# FIXME: 处理边界情况
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                }
# NOTE: 重要实现细节
            }
# 增强安全性
            catch (Exception ex)
            {
                Debug.LogError($"Error calculating SHA256 hash: {ex.Message}");
                return null;
# FIXME: 处理边界情况
            }
        }

        // 计算SHA512哈希值
        public string CalculateSHA512Hash(string input)
# 添加错误处理
        {
            try
            {
                using (var sha512 = SHA512.Create())
                {
# TODO: 优化性能
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = sha512.ComputeHash(inputBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error calculating SHA512 hash: {ex.Message}");
                return null;
            }
        }
    }
}
