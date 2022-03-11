using FullCal.Data;
using FullCal.Helpers;
using FullCal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FullCal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDAL _idal;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IDAL idal, UserManager<ApplicationUser> usermanager)
        {
            _logger = logger;
            _idal = idal;
            _userManager = usermanager;
        }

        public IActionResult Index()
        {
            //var myevent = _idal.GetEvent(1);
            ViewData["Resources"] = JSONListhelper.GetResourceListJSONString(_idal.GetProcesses());
            ViewData["Events"] = JSONListhelper.GetEventListJSONString(_idal.GetEvents());
            return View();
        }
        [Authorize]
        public IActionResult AuditCalendar()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListhelper.GetResourceListJSONString(_idal.GetProcesses());
            ViewData["Events"] = JSONListhelper.GetEventListJSONString(_idal.GetMyEvents(userid));
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