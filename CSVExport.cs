using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG282Project
{
    internal class CSVExport
    {
        public void ExportToCSV()
        {
            FileManager fileManager = new FileManager();
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine("StudentID,Name,Age,Course");

                List<Student> AllStudents = fileManager.GetAllStudents();
                foreach (var student in AllStudents)
                {
                    csvContent.AppendLine($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
                }

                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                MessageBox.Show("Exported to CSV successfully!");
            }
        }

    }
}
