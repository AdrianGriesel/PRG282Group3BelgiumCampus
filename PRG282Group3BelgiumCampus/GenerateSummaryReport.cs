using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282Project
{
    internal class GenerateSummaryReport
    {
        public void GenerateSummary()
        {
            //creatibg an instance of the FileManager class
            FileManager fileManager = new FileManager();
            //calling the GenerateSummary method of the FileManager to generate the summary
            fileManager.GenerateSummary();
        }
    }
}
