using FullCal.Data;
using FullCal.Helpers;
using FullCal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FullCal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDAL _idal;

        public HomeController(ILogger<HomeController> logger, IDAL idal)
        {
            _logger = logger;
            _idal = idal;
        }

        public IActionResult Index()
        {
            //var myevent = _idal.GetEvent(1);
            ViewData["Resources"] = JSONListhelper.GetResourceListJSONString(_idal.GetProcesses());
            ViewData["Events"] = JSONListhelper.GetEventListJSONString(_idal.GetEvents());
            return View();
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