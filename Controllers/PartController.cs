using InternetPcPartDatabase.Data;
using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;

namespace InternetPcPartDatabase.Controllers
{
    public class PartController : Controller
    {
        private readonly PartContext? _context;
        public PartController(PartContext context)
        {
            this._context = context;
        }
        // Get parts from database
        public IActionResult Index()
        {
            List<Part> parts = 
                (from p in _context.Parts
                select p).ToList();

            return View(parts);
        }

        // Add to database
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Part part)
        {
        if (ModelState.IsValid)
            {
                // Add to DB
                _context.Parts.Add(part);
                _context.SaveChanges();

                // redirect back to part page
                return RedirectToAction("Index");
            }
            return View(part);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // get part with corresponding id
            Part p =
                await (from part in _context.Parts
                where part.PartId == id
                select part).SingleAsync();
            // pass part to view
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Part part)
        {
            string partName = part.PartName;

            if (ModelState.IsValid)
            {
                _context.Entry(part).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                ViewData["Message"] = $"{partName} was updated successfully.";
            }
            return View(part);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
                Part p =
                    await (from part in _context.Parts
                           where part.PartId == id
                           select part).SingleAsync();
  
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // get part with corresponding id
            Part p =
                await(from part in _context.Parts
                      where part.PartId == id
                      select part).SingleAsync();
            // pass part to view
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Part part)
        {
            if (ModelState.IsValid)
            {
               _context.Entry(part).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(part);
        }

        [HttpGet]
       public async Task<IActionResult> CPUs()
        {
            List<Part> parts =
               await (from p in _context.Parts
                      where p.PartType == "CPU"
                      select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Coolers()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Cooler"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Motherboards()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Motherboard"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> RAM()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "RAM"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> StorageDevices()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Storage"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Graphics()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Graphics"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Cases()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Case"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> PSUs()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "PSU"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Monitors()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Monitor"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Network()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Network Adapter"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Headphones()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Headphones"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Keyboards()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Keyboard"
                       select p).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Mice()
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where p.PartType == "Mouse"
                       select p).ToListAsync();

            return View(parts);
        }
    }
}
