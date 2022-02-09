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
            return View(applications);
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
            return View("Confirmation");
        }

        // Edit Button 
        [HttpGet]
        public IActionResult Edit (int taskid)
        {
            ViewBag.Categories = QuadrantContext.Categories.ToList();
            var task = QuadrantContext.Responses.Single(x => x.TaskID == taskid);
            return View("Task", task);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse ap)
        {
            QuadrantContext.Update(ap);
            QuadrantContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete (int taskid)
        {
            var task = QuadrantContext.Responses.Single(x => x.TaskID == taskid);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ap)
        {
            QuadrantContext.Responses.Remove(ap);
            QuadrantContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
