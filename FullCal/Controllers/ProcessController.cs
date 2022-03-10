#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullCal.Data;
using FullCal.Models;

namespace FullCal.Controllers
{
    public class ProcessController : Controller
    {
        private readonly IDAL _dal;

        public ProcessController(IDAL dal)
        {

            _dal = dal;
        }

        // GET: Process
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetProcesses());
        }

        // GET: Process/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var process = _dal.GetProcess((int)id);
            if (process == null)
            {
                return NotFound();
            }

            return View(process);
        }

        // GET: Process/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Process process)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dal.CreateProcess(process);
                    TempData["Alert"] = "Success! You created a process for: " + process.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "An error occurred: " + ex.Message;
                    return View(process);
                }

            }
            return View(process);
        }

    }
}

