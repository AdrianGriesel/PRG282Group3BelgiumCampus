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
            FileManager fileManager = new FileManager();
            fileManager.GenerateSummary();
        }
    }
}
