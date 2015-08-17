using System.Collections.Generic;

namespace Coreblimey.ChartExample
{
    public class ReportResponse
    {
        public ReportResponse()
        {
            this.Data = new DataHolder();
        }

        public DataHolder Data { get; set; }          
    }

    public class DataHolder
    {
        public DataHolder()
        {
            Dataset = new List<ReportData>();;
        }

        public List<ReportData> Dataset { get; set; }
    }

}