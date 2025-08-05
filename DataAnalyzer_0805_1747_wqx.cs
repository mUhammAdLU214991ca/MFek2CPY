// 代码生成时间: 2025-08-05 17:47:42
using System;
using System.Collections.Generic;

namespace StatisticsAnalyzer
{
    public class DataAnalyzer
    {
        // 数据集
        private List<double> data = new List<double>();

        // 添加数据到分析器
        public void AddData(double value)
        {
            if (double.IsNaN(value))
            {
                throw new ArgumentException("不能添加非数字（NaN）数据", nameof(value));
            }
            data.Add(value);
        }

        // 计算平均值
        public double CalculateMean()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("数据集为空，无法计算平均值");
            }
            double sum = 0.0;
            foreach (var value in data)
            {
                sum += value;
            }
            return sum / data.Count;
        }

        // 计算中位数
        public double CalculateMedian()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("数据集为空，无法计算中位数");
            }
            data.Sort();
            double median = data[data.Count / 2];
            if (data.Count % 2 == 0)
            {
                median = (data[data.Count / 2 - 1] + data[data.Count / 2]) / 2;
            }
            return median;
        }

        // 计算标准差
        public double CalculateStandardDeviation()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("数据集为空，无法计算标准差");
            }
            double mean = CalculateMean();
            double sum = 0.0;
            foreach (var value in data)
            {
                sum += Math.Pow(value - mean, 2);
            }
            return Math.Sqrt(sum / data.Count);
        }

        // 重置数据集
        public void ResetData()
        {
            data.Clear();
        }
    }
}
