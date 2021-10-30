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
       public async Task<IActionResult> CPUs(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "CPU"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Coolers(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Cooler"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Motherboards(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Motherboard"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> RAM(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "RAM"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> StorageDevices(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Storage"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Graphics(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Graphics"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Cases(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Case"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> PSUs(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "PSU"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Monitors(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Monitor"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Network(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Network Adapter"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Headphones(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Headphones"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Keyboards(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Keyboard"
                       select part).ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Mice(Part part)
        {
            List<Part> parts =
                await (from p in _context.Parts
                       where part.PartType == "Mouse"
                       select part).ToListAsync();

            return View(parts);
        }
    }
}
