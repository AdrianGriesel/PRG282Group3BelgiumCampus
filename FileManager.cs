using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PRG282Project
{
    internal class FileManager
    {
        private readonly string studentFilePath = "students.txt";
        private readonly string summaryFilePath = "summary.txt";

        public FileManager()
        {
            //creating files if they do not exist
            if (!File.Exists(studentFilePath)) File.Create(studentFilePath).Dispose();
            if (!File.Exists(summaryFilePath)) File.Create(summaryFilePath).Dispose();
        }

        public bool AddStudent(Student student)
        {
            //checking for duplicate StudentIDs
            foreach (var s in GetAllStudents())
            {
                if (s.StudentID == student.StudentID)
                {
                    return false;//and outputs flase if already exists
                }
            }

            //adding student
            using (StreamWriter writer = new StreamWriter(studentFilePath, true))
            {
                writer.WriteLine($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
            }
            return true;
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();


            //checking if the file exists, then reading and passing thru each line
            if (File.Exists(studentFilePath))
            {
                var lines = File.ReadAllLines(studentFilePath);
                foreach (var line in lines)
                {
                    var fields = line.Split(',');

                    //checking for correct format and creainge a Student object
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

            //returning the list of students
            return students;
        }

        public bool UpdateStudent(Student updatedStudent)
        {
            var students = GetAllStudents();
            Student existingStudent = null;

            //finding the student with the matching ID
            foreach (var student in students)
            {
                if (student.StudentID == updatedStudent.StudentID)
                {
                    existingStudent = student;
                    break;
                }
            }

            if (existingStudent == null)
                return false; //when student not found

            //updating the student's info
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Course = updatedStudent.Course;

            WriteStudentsToFile(students); //saving updated list to file
            return true; //when updating is successful
        }

        public bool DeleteStudent(string studentId)
        {
            var students = GetAllStudents();
            Student student = null;

            //finding the student with the matching ID
            foreach (var s in students)
            {
                if (s.StudentID == studentId)
                {
                    student = s;
                    break;
                }
            }

            if (student == null)
                return false; //when student is not found

            students.Remove(student);
            WriteStudentsToFile(students); //saving changes to txt file
            return true; //when successfully deleted

        }

        public void GenerateSummary()
        {
            var students = GetAllStudents();
            if (students.Count == 0) return; //if no students to process return

            int totalStudents = students.Count;
            double totalAge = 0;

            //calculating total age
            foreach (var s in students)
            {
                totalAge += s.Age;
            }

            //calculating average age
            double averageAge;
            if (totalStudents > 0)
            {
                averageAge = totalAge / totalStudents;
            }
            else
            {
                averageAge = 0; //if no students, average age is 0
            }

            using (StreamWriter writer = new StreamWriter(summaryFilePath, false))
            {
                writer.WriteLine($"Total Students: {totalStudents}");
                writer.WriteLine($"Average Age: {averageAge:F2}");
            }

        }

        public List<string> Search(string cmbViaValue, string SearchVia)
        {
            List<Student> studentsList = GetAllStudents();
            List<string> SearchResults = new List<string>();
            switch (cmbViaValue)
            {
                case "Student ID":
                    foreach (var item in studentsList)
                    {
                        if (item.StudentID == SearchVia) //check if the student ID matches the search criteria
                        {
                            SearchResults.Add(item.StudentID);
                            SearchResults.Add(item.Name);
                            SearchResults.Add(item.Age.ToString());
                            SearchResults.Add(item.Course);
                        }

                    }
                    break;

                case "Name":
                    foreach (var item in studentsList)
                    {
                        if (item.Name == SearchVia)//check if the student Name matches the search criteria
                        {
                            SearchResults.Add(item.StudentID);
                            SearchResults.Add(item.Name);
                            SearchResults.Add(item.Age.ToString());
                            SearchResults.Add(item.Course);
                        }
                    }
                    break;

                case "Age":
                    foreach (var item in studentsList)
                    {
                        if (item.Age.ToString() == SearchVia)//check if the student Age matches the search criteria
                        {
                            SearchResults.Add(item.StudentID);
                            SearchResults.Add(item.Name);
                            SearchResults.Add(item.Age.ToString());
                            SearchResults.Add(item.Course);
                        }
                    }
                    break;

                case "Course":
                    foreach (var item in studentsList)
                    {
                        if (item.Course == SearchVia)//check if the student course matches the search criteria
                        {
                            SearchResults.Add(item.StudentID);
                            SearchResults.Add(item.Name);
                            SearchResults.Add(item.Age.ToString());
                            SearchResults.Add(item.Course);
                        }
                    }
                    break;

                default:
                    break;
                  
            }
            return SearchResults;
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
