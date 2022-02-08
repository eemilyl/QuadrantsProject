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
            var applications = QuadrantContext.Responses
               .Include(x => x.Category)
               .Where(x => x.Completed == false)
               .ToList();
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

        // Edit Button 
        [HttpGet]
        public IActionResult Edit (int taskid)
        {
            ViewBag.Categories = QuadrantContext.Categories.ToList();
            var task = QuadrantContext.Responses.Single(x => x.TaskID == taskid);
            return RedirectToAction("Task");
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            QuadrantContext.Update(ar);
            QuadrantContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
