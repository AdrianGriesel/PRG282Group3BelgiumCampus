using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PRG282Project
{
    internal class FileManager
    {
        private readonly string studentFilePath = "students.txt";
        private readonly string summaryFilePath = "summary.txt";

        public FileManager()
        {
            // Create files if they do not exist
            if (!File.Exists(studentFilePath)) File.Create(studentFilePath).Dispose();
            if (!File.Exists(summaryFilePath)) File.Create(summaryFilePath).Dispose();
        }

        public bool AddStudent(Student student)
        {
            // Check for duplicate StudentID
            if (GetAllStudents().Any(s => s.StudentID == student.StudentID))
            {
                return false; // Student already exists
            }

            using (StreamWriter writer = new StreamWriter(studentFilePath, true))
            {
                writer.WriteLine($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
            }
            return true; // Successfully added
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            if (File.Exists(studentFilePath))
            {
                var lines = File.ReadAllLines(studentFilePath);
                foreach (var line in lines)
                {
                    var fields = line.Split(',');

                    if (fields.Length == 4)
                    {
                        students.Add(new Student
                        {
                            StudentID = fields[0],
                            Name = fields[1],
                            Age = int.Parse(fields[2]),
                            Course = fields[3]
                        });
                    }
                }
            }

            return students;
        }

        public bool UpdateStudent(Student updatedStudent)
        {
            var students = GetAllStudents();
            var existingStudent = students.FirstOrDefault(s => s.StudentID == updatedStudent.StudentID);

            if (existingStudent == null)
                return false; // Student not found

            // Update student information
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Course = updatedStudent.Course;

            WriteStudentsToFile(students); // Save changes to file
            return true; // Successfully updated
        }

        public bool DeleteStudent(string studentId)
        {
            var students = GetAllStudents();
            var student = students.FirstOrDefault(s => s.StudentID == studentId);

            if (student == null)
                return false; // Student not found

            students.Remove(student); // Remove student from list
            WriteStudentsToFile(students); // Save changes to file
            return true; // Successfully deleted
        }

        public void GenerateSummary()
        {
            var students = GetAllStudents();
            if (students.Count == 0) return;

            int totalStudents = students.Count;
            double averageAge = students.Average(s => s.Age);

            using (StreamWriter writer = new StreamWriter(summaryFilePath, false))
            {
                writer.WriteLine($"Total Students: {totalStudents}");
                writer.WriteLine($"Average Age: {averageAge:F2}");
            }
        }

        private void WriteStudentsToFile(List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter(studentFilePath, false))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
                }
            }
        }
    }
}
