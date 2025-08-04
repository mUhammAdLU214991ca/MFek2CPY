// 代码生成时间: 2025-08-05 07:09:44
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;

// Excel表格自动生成器类
public class ExcelGenerator
{
    private string filePath;
    private XLWorkbook workbook;

    public ExcelGenerator(string filePath)
    {
        this.filePath = filePath;
        workbook = new XLWorkbook();
    }

    // 创建新的工作表
    public void AddWorksheet(string sheetName)
    {
        workbook.Worksheets.Add(sheetName);
    }

    // 向工作表添加标题行
    public void AddTitleRow(string sheetName, List<string> headers)
    {
        var worksheet = workbook.Worksheet(sheetName);
        for (int i = 0; i < headers.Count; i++)
        {
            worksheet.Cell(1, i + 1).Value = headers[i];
        }
    }

    // 向工作表添加数据行
    public void AddDataRow(string sheetName, List<string> data)
    {
        var worksheet = workbook.Worksheet(sheetName);
        worksheet.Cell(worksheet.RowCount + 1, 1).Value = string.Join(" ", data);
    }

    // 保存Excel文件
    public void Save()
    {
        try
        {
            workbook.SaveAs(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving the Excel file: " + ex.Message);
        }
    }

    // 示例方法：生成一个简单的Excel文件
    public static void GenerateSampleExcel(string path)
    {
        ExcelGenerator generator = new ExcelGenerator(path);
        generator.AddWorksheet("SampleSheet");
        generator.AddTitleRow("SampleSheet", new List<string>{"ID", "Name", "Age"});
        generator.AddDataRow("SampleSheet", new List<string>{"1", "John Doe", "30"});
        generator.AddDataRow("SampleSheet", new List<string>{"2", "Jane Smith", "25"});
        generator.Save();
    }
}
