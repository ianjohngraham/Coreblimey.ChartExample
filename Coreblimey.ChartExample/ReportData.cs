using System.Collections.Generic;

namespace Coreblimey.ChartExample
{
    public class ReportData
    {
        public ReportData()
        {
            this.Data = new List<Dictionary<string, string>>();
        }
   
        public List<Dictionary<string, string>> Data { get; set; }

        public void AddRow(Dictionary<string, string> row)
        {
            this.Data.Add(row);
        }
    }
}