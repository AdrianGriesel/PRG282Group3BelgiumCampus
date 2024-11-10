using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG282Project
{
    public partial class frmMain : Form
    {
        private FileManager fileManager;
        public frmMain()
        {
            InitializeComponent();
            fileManager = new FileManager();
            LoadStudentsToGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadStudentsToGrid()
        {
            var students = fileManager.GetAllStudents();
            dgvStudents.DataSource = students;
        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            //cell click exists 
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dgvStudents.SelectedRows[0];
                var studentId = selectedRow.Cells["StudentID"].Value.ToString();
                var name = selectedRow.Cells["Name"].Value.ToString();
                var age = selectedRow.Cells["Age"].Value.ToString();
                var course = selectedRow.Cells["Course"].Value.ToString();

                // Show current information in a message box
                string message = $"Current Information:\n\n" +
                                 $"ID: {studentId}\n" +
                                 $"Name: {name}\n" +
                                 $"Age: {age}\n" +
                                 $"Course: {course}\n\n" +
                                 "Enter new values or leave blank to keep current.";

                string newName = Prompt.ShowDialog("Update Name:", message);
                string newAgeStr = Prompt.ShowDialog("Update Age:", "Update Age:");
                string newCourse = Prompt.ShowDialog("Update Course:", "Update Course:");

                // Create updated student object
                var updatedStudent = new Student
                {
                    StudentID = studentId,
                    Name = string.IsNullOrWhiteSpace(newName) ? name : newName,
                    Age = string.IsNullOrWhiteSpace(newAgeStr) || !int.TryParse(newAgeStr, out int newAge) ? int.Parse(age) : newAge,
                    Course = string.IsNullOrWhiteSpace(newCourse) ? course : newCourse
                };

                if (fileManager.UpdateStudent(updatedStudent))
                {
                    MessageBox.Show("Student updated successfully.");
                    LoadStudentsToGrid();
                }
                else
                {
                    MessageBox.Show("Error updating student.");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            //cell click exsists 
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var studentId = dgvStudents.SelectedRows[0].Cells[0].Value.ToString();
                if (fileManager.DeleteStudent(studentId))
                {
                    MessageBox.Show("Student deleted successfully.");
                    LoadStudentsToGrid();
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            } 
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Prompt for student information
            string studentId = Prompt.ShowDialog("Enter Student ID:", "Add Student");
            string name = Prompt.ShowDialog("Enter Name:", "Add Student");
            string ageStr = Prompt.ShowDialog("Enter Age:", "Add Student");
            string course = Prompt.ShowDialog("Enter Course:", "Add Student");

            // Validate inputs
            if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(name) ||
                !int.TryParse(ageStr, out int age) || age <= 0 || string.IsNullOrWhiteSpace(course))
            {
                MessageBox.Show("Please enter valid data for all fields.");
                return;
            }

            // Create new student object and add it
            var newStudent = new Student
            {
                StudentID = studentId,
                Name = name,
                Age = age,
                Course = course
            };

            // Use the instance of FileManager to call AddStudent
            if (fileManager.AddStudent(newStudent)) // Fixed line here
            {
                MessageBox.Show("Student added successfully.");
                LoadStudentsToGrid();
            }
            else
            {
                MessageBox.Show("Student with this ID already exists.");
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {

            fileManager.GenerateSummary();
            MessageBox.Show("Summary report generated.");//(As a text file by the name "summary" in bin->debug)
        }

        private void btnViewAllStudents_Click(object sender, EventArgs e)
        {

        }

        private void cmbVia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string option = cmbVia.SelectedItem.ToString();
            string SearchVia = txtSearchVia.Text;
            dgvStudents.DataSource = fileManager.Search(option,SearchVia);

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CSVExport ce = new CSVExport();
            ce.ExportToCSV();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            frmDebugger frmDebugger = new frmDebugger();
            this.Hide();
            frmDebugger.ShowDialog();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
} 
