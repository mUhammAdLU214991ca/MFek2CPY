// 代码生成时间: 2025-09-18 03:29:25
using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
/// Excel表格自动生成器
/// </summary>
public class ExcelGenerator
{
    /// <summary>
    /// 生成Excel文件
    /// </summary>
    /// <param name="data">用于填充Excel的数据</param>
    /// <param name="filePath">生成Excel文件的路径</param>
    /// <returns>生成Excel文件的结果</returns>
    public bool GenerateExcel(DataTable data, string filePath)
    {
        try
        {
            // 创建Excel应用
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            // 添加一个工作簿
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // 将DataTable数据填充到Excel
            FillExcelWithData(worksheet, data);

            // 保存Excel文件
            workbook.SaveAs(filePath);

            // 关闭工作簿和Excel应用
            workbook.Close();
            excelApp.Quit();

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"生成Excel文件时发生错误: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 将DataTable数据填充到Excel
    /// </summary>
    /// <param name="worksheet">Excel工作表</param>
    /// <param name="data">用于填充Excel的数据</param>
    private void FillExcelWithData(Excel.Worksheet worksheet, DataTable data)
    {
        // 遍历DataTable的每一行数据
        for (int i = 0; i < data.Rows.Count; i++)
        {
            for (int j = 0; j < data.Columns.Count; j++)
            {
                // 将数据填充到Excel单元格
                worksheet.Cells[i + 1, j + 1] = data.Rows[i][j].ToString();
            }
        }
    }
}
