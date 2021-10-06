using InternetPcPartDatabase.Data;
using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Mvc;

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


    }
}
