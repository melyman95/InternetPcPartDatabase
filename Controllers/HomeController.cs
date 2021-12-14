﻿using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternetPcPartDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailProvider _emailProvider;

        public HomeController(ILogger<HomeController> logger, IEmailProvider emailProvider)
        {
            _logger = logger;
            _emailProvider = emailProvider;
        }

        public async Task<IActionResult> Index()
        {
            await _emailProvider.SendEmailAsync(null, null, null, null, null);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}