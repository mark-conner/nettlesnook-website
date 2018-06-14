using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nettlesnook.Controllers
{
    public class FermentingController : Controller
    {
        public IActionResult Index()
        {
            ViewData["cssType"] = "index";

            return View();
        }

        public IActionResult Beverages()
        {
            return View();
        }

        public IActionResult Sourdough()
        {
            return View();
        }

        public IActionResult Vegetables()
        {
            return View();
        }
    }
}