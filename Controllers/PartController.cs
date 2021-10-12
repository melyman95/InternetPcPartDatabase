using InternetPcPartDatabase.Data;
using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
