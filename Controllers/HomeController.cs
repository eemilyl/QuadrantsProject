using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuadrantsProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrantsProject.Controllers
{

    public class HomeController : Controller
    {
        private QuadrantApplicationContext QuadrantContext { get; set; }

        public HomeController(QuadrantApplicationContext x)
        {
            QuadrantContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        // for the form 
        [HttpGet]
        public IActionResult Task()
        {
            ViewBag.Categories = QuadrantContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Task(ApplicationResponse ap)
        {
            QuadrantContext.Add(ap);
            QuadrantContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
