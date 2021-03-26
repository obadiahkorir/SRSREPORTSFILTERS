using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleDemoMVC.Models;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace SampleDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(ListedHouseholdsViewModel vm)
        {

          
            ViewBag.ConstituencyId = new SelectList(await _context.Constituencies.OrderBy(i => i.Name)
                           .ToListAsync(), "Id", "Name", vm.ConstituencyId);

            ViewBag.LocationId =
                new SelectList(
                    await _context.Locations.OrderBy(i => i.Name).ToListAsync(), "Id", "Name", vm.LocationId);

            ViewBag.SexId =
                new SelectList(
                    await _context.SystemCodeDetails.OrderBy(i => i.OrderNo)
                        .Where(i => i.SystemCode.Code == "Sex").ToListAsync(), "Id", "Description",
                    vm.SexId);


            ViewBag.RelationshipId =
                new SelectList(
                    await _context.SystemCodeDetails.OrderBy(i => i.OrderNo)
                        .Where(i => i.SystemCode.Code == "Relationship").ToListAsync(), "Id", "Description",
                    vm.RelationshipId);

            ViewBag.MemberRoleId =
           new SelectList(
               await _context.SystemCodeDetails.OrderBy(i => i.OrderNo)
                   .Where(i => i.SystemCode.Code == "Member Role").ToListAsync(), "Id", "Description",
               vm.MemberRoleId);

            ViewBag.ProgrammeId = new SelectList(await _context.Programmes.ToListAsync(), "Id", "Code", vm.ProgrammeId);

            
            //Bold Reports Filters.
            List<BoldReports.Models.ReportViewer.ReportParameter> parameters = new List<BoldReports.Models.ReportViewer.ReportParameter>();
            parameters.Add(new BoldReports.Models.ReportViewer.ReportParameter()
            {
                Name = "NationalIdNo", Values = new List<string>() { vm.NationalIdNo },

            });
            parameters.Add(new BoldReports.Models.ReportViewer.ReportParameter()
            {
                Name = "SexId",
                Values = new List<string>() { Convert.ToString(vm.SexId) },

            });

            ViewBag.parameters = parameters;

            parameters.Add(new BoldReports.Models.ReportViewer.ReportParameter()
            {
                Name = "StatusId",
                Values = new List<string>() { Convert.ToString(vm.StatusId)},

            });
            parameters.Add(new BoldReports.Models.ReportViewer.ReportParameter()
            {
                Name = "RelationshipId",
                Values = new List<string>() { Convert.ToString(vm.RelationshipId) },

            });

            ViewBag.parameters = parameters;

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}
