using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sitecore.Analytics.Reporting;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.ExperienceAnalytics.Api;
using Sitecore.Services.Infrastructure.Web.Http;

namespace Coreblimey.ChartExample
{

    public class VisitDataController : ServicesApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
             // Use ReportDataProvider 
             ReportDataProviderBase reportingDataProvider = ApiContainer.Configuration.GetReportingDataProvider();
             var cachingPolicy = new CachingPolicy
             {
                 ExpirationPeriod = Config.CacheExpiration
             };

             // Load data from a Custom template in core containing a SQL query field. This gets the SQL we need to query the Fact table
             Item dataSourceItem = Database.GetDatabase("core").GetItem(new ID("{97502B91-E580-4DAD-A2F5-8E06F4D0554A}"));
             var reportSqlQuery = dataSourceItem.Fields["SQL"].Value;

             // Use ReportDataQuery to load data from reporting database Fact table
             var query = new ReportDataQuery(reportSqlQuery);
             var table = reportingDataProvider.GetData("reporting", query, cachingPolicy).GetDataTable();

             // Create two dictionaries to store data
             Dictionary<string, string> returnVisitData = new Dictionary<string, string>();
             Dictionary<string, string> newVisitData = new Dictionary<string, string>();

             // Add two values to each dictionary
             returnVisitData.Add("VisitType", "Return Visitors");
             returnVisitData.Add("Visits", table.Rows[0]["VisitData"].ToString());
             newVisitData.Add("VisitType", "New Visitors");
             newVisitData.Add("Visits", table.Rows[1]["VisitData"].ToString());

             // Data must conform to format:
             //{"data":{"dataset":[{"data":[
             // So using Report Data class to aid with serialization to correct format 

             var reportdata = new ReportData();
             reportdata.AddRow(returnVisitData);
             reportdata.AddRow(newVisitData);

             var response = new ReportResponse();
             response.Data.Dataset.Add(reportdata);

             //output to Json
             return new JsonResult<ReportResponse>(response,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() },
                    Encoding.UTF8, this);
        }
    }
}