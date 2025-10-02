// 代码生成时间: 2025-10-03 01:42:28
using System;
using System.Collections.Generic;

// Define a simple student class for campus management
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public Student(string name, int age, string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }
}

// Define a campus management system class
public class CampusManagement
{
    private List<Student> students;

    public CampusManagement()
    {
        students = new List<Student>();
    }

    // Add a new student to the campus
    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("student", "Cannot add a null student to the campus.");
        }
        students.Add(student);
    }

    // Remove a student from the campus
    public void RemoveStudent(string studentName)
    {
        var studentToRemove = students.Find(s => s.Name == studentName);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
        }
        else
        {
            throw new KeyNotFoundException("There is no student with the name: " + studentName);
        }
    }

    // Get all students in the campus
    public List<Student> GetAllStudents()
    {
        return new List<Student>(students); // Return a copy to prevent external modifications
    }

    // Find a student by name
    public Student FindStudent(string studentName)
    {
        var student = students.Find(s => s.Name == studentName);
        if (student != null)
        {
            return student;
        }
        else
        {
            throw new KeyNotFoundException("There is no student with the name: " + studentName);
        }
    }
}

// Example usage of the CampusManagement class
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var campus = new CampusManagement();
            campus.AddStudent(new Student("John Doe", 20, "A"));
            campus.AddStudent(new Student("Jane Doe", 21, "B"));

            var students = campus.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}, Age: {1}, Grade: {2}", student.Name, student.Age, student.Grade);
            }

            campus.RemoveStudent("John Doe");

            Console.WriteLine("Students after removal: ");
            var remainingStudents = campus.GetAllStudents();
            foreach (var student in remainingStudents)
            {
                Console.WriteLine("Name: {0}, Age: {1}, Grade: {2}", student.Name, student.Age, student.Grade);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}