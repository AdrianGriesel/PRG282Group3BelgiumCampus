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
  
            try
            {
                //initializing the form components
                InitializeComponent();

                //initializing the FileManager instance
                fileManager = new FileManager();

                //loading students into the DataGridView
                LoadStudentsToGrid();
            }
            catch (NullReferenceException)
            {
                //handling cases where an object might be null
                MessageBox.Show("A required component was not initialized correctly. Please check your setup.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //catching any unexpected errors
                MessageBox.Show("An unexpected error occurred during initialization: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadStudentsToGrid()
        {
            try
            {
                //trying to retrieve all students
                var students = fileManager.GetAllStudents();

                //checking if the returned list is null or empty
                if (students == null)
                {
                    MessageBox.Show("Failed to retrieve student data. Please try again.", "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (students.Count == 0)
                {
                    MessageBox.Show("No student records found.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //seting the data source of the DataGridView
                dgvStudents.DataSource = students;
            }
            catch (Exception ex)
            {
                //catching any unexpected errors
                MessageBox.Show("An unexpected error occurred while loading student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //ensuring a row is selected
                if (dgvStudents.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvStudents.SelectedRows[0];

                    //trying to retrieve the existing student details
                    var studentIdCell = selectedRow.Cells["StudentID"].Value;
                    var nameCell = selectedRow.Cells["Name"].Value;
                    var ageCell = selectedRow.Cells["Age"].Value;
                    var courseCell = selectedRow.Cells["Course"].Value;

                    //validating that cells contain data
                    if (studentIdCell == null || nameCell == null || ageCell == null || courseCell == null)
                    {
                        MessageBox.Show("Selected student information is incomplete or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string studentId = studentIdCell.ToString();
                    string name = nameCell.ToString();
                    string age = ageCell.ToString();
                    string course = courseCell.ToString();

                    //showing current information and prompt for updates
                    string message = $"Current Information:\n\n" +
                                     $"ID: {studentId}\n" +
                                     $"Name: {name}\n" +
                                     $"Age: {age}\n" +
                                     $"Course: {course}\n\n" +
                                     "Enter new values or leave blank to keep current.";

                    string newName = Prompt.ShowDialog("Update Name:", message);
                    string newAgeStr = Prompt.ShowDialog("Update Age:", "Update Age:");
                    string newCourse = Prompt.ShowDialog("Update Course:", "Update Course:");

                    //parsing the new age, falling back to the current age if input is invalid
                    int newAge;
                    if (string.IsNullOrWhiteSpace(newAgeStr) || !int.TryParse(newAgeStr, out newAge) || newAge <= 0)
                    {
                        newAge = int.Parse(age); // Use the current age if parsing fails or age is invalid
                    }

                    //creating updated student object
                    var updatedStudent = new Student
                    {
                        StudentID = studentId,
                        Name = string.IsNullOrWhiteSpace(newName) ? name : newName,
                        Age = newAge,
                        Course = string.IsNullOrWhiteSpace(newCourse) ? course : newCourse
                    };

                    //trying to update the student in fileManager
                    if (fileManager.UpdateStudent(updatedStudent))
                    {
                        MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudentsToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error updating student. The student record may not exist or could not be updated.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                //handling formatting errors for age input
                MessageBox.Show("Invalid format entered for age. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                //catching any other unexpected errors
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //checking if a row is selected
                if (dgvStudents.SelectedRows.Count > 0)
                {
                    //trying to retrieve the Student ID
                    var studentIdCell = dgvStudents.SelectedRows[0].Cells[0].Value;
                    if (studentIdCell == null || string.IsNullOrWhiteSpace(studentIdCell.ToString()))
                    {
                        MessageBox.Show("Invalid student ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var studentId = studentIdCell.ToString();

                    //trying to delete the student
                    if (fileManager.DeleteStudent(studentId))
                    {
                        MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudentsToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Student not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //catching any unexpected errors
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //prompting for student information
                string studentId = Prompt.ShowDialog("Enter Student ID:", "Add Student");
                string name = Prompt.ShowDialog("Enter Name:", "Add Student");
                string ageStr = Prompt.ShowDialog("Enter Age:", "Add Student");
                string course = Prompt.ShowDialog("Enter Course:", "Add Student");

                //validating inputs
                if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(ageStr) || string.IsNullOrWhiteSpace(course))
                {
                    MessageBox.Show("Please enter valid data for all fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //validating age input
                if (!int.TryParse(ageStr, out int age) || age <= 0)
                {
                    MessageBox.Show("Please enter a valid positive integer for age.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //creating new student object
                var newStudent = new Student
                {
                    StudentID = studentId,
                    Name = name,
                    Age = age,
                    Course = course
                };

                //trying to add the student
                if (fileManager.AddStudent(newStudent))
                {
                    MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentsToGrid();
                }
                else
                {
                    MessageBox.Show("A student with this ID already exists. Please use a unique ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //catching any unexpected errors
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                //trying to generate the summary report
                fileManager.GenerateSummary();

                //confirming successful generation
                MessageBox.Show("Summary report generated successfully as 'summary.txt' in the bin\\debug folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                //handling cases where the application doesn't have permission to write to the directory
                MessageBox.Show("Permission denied: Unable to write to the specified directory.\n" + ex.Message, "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                //handling general I/O errors (e.g., file in use or disk error)
                MessageBox.Show("An error occurred while generating the summary report.\n" + ex.Message, "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //catching any other unexpected errors
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnViewAllStudents_Click(object sender, EventArgs e)
        {

        }

        private void cmbVia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //checking if a search option has been selected
                if (cmbVia.SelectedItem == null)
                {
                    throw new InvalidOperationException("Please select a search option.");
                }

                //making the selected option a string
                string option = cmbVia.SelectedItem.ToString();

                //checking if search input is provided
                string SearchVia = txtSearchVia.Text.Trim();
                if (string.IsNullOrEmpty(SearchVia))
                {
                    throw new ArgumentException("Search input cannot be empty.");
                }

                //performing the search
                var searchResults = fileManager.Search(option, SearchVia);

                //checking if search results are empty
                if (searchResults == null || searchResults.Count == 0)
                {
                    MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvStudents.DataSource = null; //clearing previous data if no results found
                }
                else
                {
                    dgvStudents.DataSource = searchResults; //displaying the search results
                }
            }
            catch (InvalidOperationException ex)
            {
                //handling cases where the selection or search option is invalid
                MessageBox.Show(ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                //handling empty search input
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                //handling any other unexpected errors
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //initialising the CSVExport instance
                CSVExport ce = new CSVExport();

                //trying to export data to CSV
                ce.ExportToCSV();

                //notifying user of successful export
                MessageBox.Show("Data exported successfully to CSV.", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                //handling permission issues
                MessageBox.Show("You do not have permission to write to the selected file location. Please choose a different location or check your permissions.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                //handling general file I/O errors, such as file being in use
                MessageBox.Show("An error occurred while accessing the file: " + ioEx.Message, "File Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //handling any other unexpected errors
                MessageBox.Show("An unexpected error occurred during CSV export: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            try
            {
                //trying to initialize the debugger form
                frmDebugger frmDebugger = new frmDebugger();

                //hiding the current form
                this.Hide();

                //showing the debugger form as a modal dialog
                frmDebugger.ShowDialog();

                //showing the current form again after closing frmDebugger
                this.Show();
            }
            catch (InvalidOperationException)
            {
                //handling cases where the form is already closed or cannot be hidden/shown
                MessageBox.Show("An error occurred while trying to display the debugger form. Please try again.", "Form Display Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //ensur\ing the current form remains visible if hiding fails
                this.Show();
            }
            catch (Exception ex)
            {
                //catching any other unexpected errors
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //ensuring the current form remains visible in case of errors
                this.Show();
            }

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
} 
