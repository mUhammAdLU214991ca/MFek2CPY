// 代码生成时间: 2025-10-07 02:26:22
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  考勤打卡系统
/// </summary>
public class AttendanceSystem : MonoBehaviour
{
    /// <summary>
    /// 存储员工打卡记录
    /// </summary>
    private List<AttendanceRecord> attendanceRecords = new List<AttendanceRecord>();

    /// <summary>
    /// 员工打卡
    /// </summary>
    /// <param name="employeeId">员工ID</param>
    /// <param name="timeIn">打卡时间</param>
    /// <returns>打卡成功返回true，失败返回false</returns>
    public bool ClockIn(string employeeId, DateTime timeIn)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            Debug.LogError("Employee ID cannot be null or empty.");
            return false;
        }

        AttendanceRecord record = new AttendanceRecord
        {
            EmployeeId = employeeId,
            TimeIn = timeIn
        };

        attendanceRecords.Add(record);
        return true;
    }

    /// <summary>
    /// 获取员工打卡记录
    /// </summary>
    /// <param name="employeeId">员工ID</param>
    /// <returns>员工的打卡记录列表</returns>
    public List<AttendanceRecord> GetAttendanceRecords(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            Debug.LogError("Employee ID cannot be null or empty.");
            return new List<AttendanceRecord>();
        }

        return attendanceRecords.FindAll(record => record.EmployeeId == employeeId);
    }

    /// <summary>
    /// 考勤记录类
    /// </summary>
    public class AttendanceRecord
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        public DateTime TimeIn { get; set; }
    }
}
