using System.Web.Http;
using Sitecore.Pipelines;

namespace Coreblimey.ChartExample
{
    public class RegisterHttpRoutes
    {
        public void Process(PipelineArgs args)
        {
            GlobalConfiguration.Configure(Configure);
        }
        protected void Configure(HttpConfiguration configuration)
        {
            var routes = configuration.Routes;
            routes.MapHttpRoute("visitdataapi", "sitecore/api/visitdata", new
            {
                controller = "visitdata",
                action = "Get"
            });
        }
    }
}