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
    public partial class frmDebugger : Form
    {
        public frmDebugger()
        {
            InitializeComponent();
        }

        private void Debugger_Load(object sender, EventArgs e)
        {

        }

        private void btnSqlTest_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            List<Student> students = fileManager.GetAllStudents();

            string query = txtSql.Text.ToUpper(); // Get query from the TextBox
            IEnumerable<Student> queryResult = students; 

            try
            {
                // Handle SELECT query
                if (query.StartsWith("SELECT * FROM STUDENTS"))
                {
                    
                    string whereClause = query.Contains("WHERE") ? query.Substring(query.IndexOf("WHERE") + 5).Trim() : "";

                    if (!string.IsNullOrEmpty(whereClause))
                    {
                        // Split by AND or OR to handle multiple conditions
                        string[] conditions = whereClause.Split(new[] { "AND", "OR" }, StringSplitOptions.None);

                        foreach (var condition in conditions)
                        {
                            if (condition.Contains("AGE >"))
                            {
                                int age = int.Parse(condition.Split('>')[1].Trim());
                                queryResult = queryResult.Where(s => s.Age > age);
                            }
                            else if (condition.Contains("AGE <"))
                            {
                                int age = int.Parse(condition.Split('<')[1].Trim());
                                queryResult = queryResult.Where(s => s.Age < age);
                            }
                            else if (condition.Contains("NAME LIKE"))
                            {
                                string[] parts = condition.Split(new[] { "LIKE" }, StringSplitOptions.None);
                                if (parts.Length > 1)
                                {
                                    string namePattern = parts[1].Trim().Trim('\'');
                                    queryResult = queryResult.Where(s => s.Name.IndexOf(namePattern, StringComparison.OrdinalIgnoreCase) >= 0);
                                }
                            }
                        }
                    }
                }

                // Convert the result to a DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("StudentID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Course");

                foreach (var student in queryResult)
                {
                    dt.Rows.Add(student.StudentID, student.Name, student.Age, student.Course);
                }

                // Send the result to the DataGridView
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            this.Hide();
            
        }
    }
}
