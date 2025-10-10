// 代码生成时间: 2025-10-11 02:18:27
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 教学质量分析类，用于分析教学数据并提供分析结果。
/// </summary>
public class TeachingQualityAnalysis
{
    private List<Teacher> teacherList;
    private List<Student> studentList;

    /// <summary>
    /// 构造函数，初始化教师和学生列表。
    /// </summary>
    public TeachingQualityAnalysis()
    {
        teacherList = new List<Teacher>();
        studentList = new List<Student>();
    }

    /// <summary>
    /// 添加教师信息。
    /// </summary>
    /// <param name="teacher">教师对象。</param>
    public void AddTeacher(Teacher teacher)
    {
        if (teacher == null)
            throw new ArgumentNullException("Teacher cannot be null.");

        teacherList.Add(teacher);
    }

    /// <summary>
    /// 添加学生信息。
    /// </summary>
    /// <param name="student">学生对象。</param>
    public void AddStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException("Student cannot be null.");

        studentList.Add(student);
    }

    /// <summary>
    /// 分析教学质量。
    /// </summary>
    /// <returns>分析结果。</returns>
    public string AnalyzeTeachingQuality()
    {
        if (teacherList.Count == 0 || studentList.Count == 0)
            throw new InvalidOperationException("No teachers or students available for analysis.");

        string result = "Teaching Quality Analysis:
";

        foreach (Teacher teacher in teacherList)
        {
            result += $"
Teacher: {teacher.Name}, Average Student Score: {CalculateAverageStudentScore(teacher)}";
        }

        return result;
    }

    /// <summary>
    /// 计算指定教师的学生平均分数。
    /// </summary>
    /// <param name="teacher">教师对象。</param>
    /// <returns>平均分数。</returns>
    private float CalculateAverageStudentScore(Teacher teacher)
    {
        List<Student> teacherStudents = GetStudentsByTeacher(teacher);

        if (teacherStudents.Count == 0)
            return 0;

        float totalScore = 0;
        foreach (Student student in teacherStudents)
        {
            totalScore += student.Score;
        }

        return totalScore / teacherStudents.Count;
    }

    /// <summary>
    /// 根据教师获取学生列表。
    /// </summary>
    /// <param name="teacher">教师对象。</param>
    /// <returns>学生列表。</returns>
    private List<Student> GetStudentsByTeacher(Teacher teacher)
    {
        List<Student> students = new List<Student>();
        foreach (Student student in studentList)
        {
            if (student.Teacher == teacher)
            {
                students.Add(student);
            }
        }

        return students;
    }
}

/// <summary>
/// 教师类。
/// </summary>
public class Teacher
{
    public string Name { get; set; }
}

/// <summary>
/// 学生类。
/// </summary>
public class Student
{
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public float Score { get; set; }
}