using BoldReports.Web;
using BoldReports.Web.ReportViewer;
using Microsoft.AspNetCore.Mvc;
using SampleDemoMVC.Models;
using System.Collections.Generic;
using System.IO;


namespace SampleDemoMVC
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportViewerController : Controller, IReportController
    {
            ListedHouseholdsViewModel model;
        // Report viewer requires a memory cache to store the information of consecutive client request and
        // have the rendered Report Viewer information in server.
        private Microsoft.Extensions.Caching.Memory.IMemoryCache _cache;

        // IHostingEnvironment used with sample to get the application data from wwwroot.
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;

        // Post action to process the report from server based json parameters and send the result back to the client.
        public ReportViewerController(Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache,
            Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            _cache = memoryCache;
            _hostingEnvironment = hostingEnvironment;
        }

        // Post action to process the report from server based json parameters and send the result back to the client.
        [HttpPost]
        public object PostReportAction([FromBody] Dictionary<string, object> jsonArray)
        {
            //Contains helper methods that help to process a Post or Get request from the Report Viewer control and return the response to the Report Viewer control
            return ReportHelper.ProcessReport(jsonArray, this, this._cache);
        }



        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream reportStream = new FileStream(basePath + @"\Resources\" + reportOption.ReportModel.ReportPath, FileMode.Open, FileAccess.Read);
            reportOption.ReportModel.Stream = reportStream;

            //Add SSRS Report Server credential
           // reportOption.ReportModel.ReportServerCredential = new System.Net.NetworkCredential("Dev Pathways", "@Devpathways2019");
            //reportOption.ReportModel.ReportServerCredential = new System.Net.NetworkCredential("sa", "@Admin890");
            reportOption.ReportModel.DataSourceCredentials.Add(new DataSourceCredentials("MyData", "sa", "@Admin890"));
            //Add SSRS Report Server and data source credentials
            reportOption.ReportModel.DataSourceCredentials.Add(new BoldReports.Web.DataSourceCredentials("MyData", "sa", "@Admin890"));
            //reportOption.ReportModel.DataSourceCredentials.Add(new BoldReports.Web.DataSourceCredentials("MyData", "sa", "@Admin890", "Data Source='197.232.65.10, 2021';Initial Catalog=CCTPMIS;"));
        }
        public void OnReportLoaded(ReportViewerOptions reportOption)
        {
            //List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>();
            //userParameters.Add(new BoldReports.Web.ReportParameter()
            //{
            //    Name = model.SexIDParameter,
            //    Values = new List<string>() { model.SexIDValue }
            //});
            //reportOption.ReportModel.Parameters = userParameters;


        }

        //Get action for getting resources from the report
        [ActionName("GetResource")]
        [AcceptVerbs("GET")]
        // Method will be called from Report Viewer client to get the image src for Image report item.
        public object GetResource(ReportResource resource)
        {
            return ReportHelper.GetResource(resource, this, _cache);
        }

        [HttpPost]
        public object PostFormReportAction()
        {
            return ReportHelper.ProcessReport(null, this, _cache);
        }

    }
}