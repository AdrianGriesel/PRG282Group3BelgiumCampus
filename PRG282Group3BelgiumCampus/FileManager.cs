using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PRG282Project
{
    internal class FileManager
    {
        private readonly string studentFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "DataFolder", "TextDocuments", "students.txt");
        private readonly string summaryFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "DataFolder", "TextDocuments", "summary.txt");
        public FileManager()
        {
           
            //creating files if they do not exist
            if (!File.Exists(studentFilePath)) File.Create(studentFilePath).Dispose();
            if (!File.Exists(summaryFilePath)) File.Create(summaryFilePath).Dispose();
        }

        public bool AddStudent(Student student)
        {

            try
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File was not found: " + ex.Message);
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {

            try
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File does not exist: " + ex.Message);
                throw;
            }
            
        }

        public bool UpdateStudent(Student updatedStudent)
        {

            try
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
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Student not found: +" + ex.Message);
                throw;
            }
            
        }

        public bool DeleteStudent(string studentId)
        {

            try
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
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Student not deleted: "+ ex.Message);
                throw;
            }
            

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
        public List<Student> Search(string cmbViaValue, string SearchVia) //changed to return list of students
        {
            List<Student> studentsList = GetAllStudents();
            List<Student> SearchResults = new List<Student>();

            SearchVia = SearchVia.Trim();

            switch (cmbViaValue)
            {
               

                case "Student ID":
                    foreach (var student in studentsList)
                    {
                        if (student.StudentID == SearchVia) //check if the student ID matches the search criteria
                        {
                            SearchResults.Add(student);
                        }

                    }
                    break;

                case "Name":
                    foreach (var student in studentsList)
                    {
                        if (student.Name.ToUpper() == SearchVia.ToUpper())//check if the student Name matches the search criteria
                        {
                            SearchResults.Add(student);
                        }
                    }
                    break;

                case "Age":
                    foreach (var student in studentsList)
                    {
                        if (student.Age.ToString() == SearchVia)//check if the student Age matches the search criteria
                        {
                            SearchResults.Add(student);
                        }
                    }
                    break;

                case "Course":
                    foreach (var student in studentsList)
                    {
                        if (student.Course.ToUpper() == SearchVia.ToUpper())//check if the student course matches the search criteria
                        {
                            SearchResults.Add(student);
                        }
                    }
                    break;

                default:
                    break;

            }
            return SearchResults;
        }
    }
}
