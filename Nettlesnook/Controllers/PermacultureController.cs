using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nettlesnook.Controllers
{
    public class PermacultureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Landscaping()
        {
            return View();
        }

        public IActionResult Herbs()
        {
            return View();
        }

        public IActionResult Vegetables()
        {
            return View();
        }
    }
}