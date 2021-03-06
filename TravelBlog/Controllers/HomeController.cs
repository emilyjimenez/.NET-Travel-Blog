﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;
using TravelBlog.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Location> model = db.Locations.ToList();
            return View(model);
        }

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Location location)
		{
			db.Locations.Add(location);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

        public IActionResult Details(int id)
        {
            var model = db.Locations
                          .Include(l => l.People)
                          .Include(l => l.Experiences)
                          .FirstOrDefault(locations => locations.LocationId == id);
            return View(model);
        }
    }
}
