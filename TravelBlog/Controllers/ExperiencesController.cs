using System;
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
    public class ExperiencesController : Controller
    {
		private TravelBlogContext db = new TravelBlogContext();

		// GET: /<controller>/
		public IActionResult AddToLocation(int locationId)
		{
			ExperienceAtLocation model = new ExperienceAtLocation();
			model.Location = db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);

			return View(model);
		}

		[HttpPost]
		public IActionResult AddToLocation(ExperienceAtLocation formResults)
		{
			Experience newExperience = new Experience();
			newExperience.Name = formResults.ExperienceName;
			newExperience.Description = formResults.ExperienceDescription;
			newExperience.LocationId = formResults.Location.LocationId;

			db.Experiences.Add(newExperience);
			db.SaveChanges();
			return RedirectToAction("Details", "Home", new { id = formResults.Location.LocationId });
		}

        [HttpGet]
        public IActionResult DeleteExperience(int experienceId)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == experienceId);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Details", "Home", new { id = thisExperience.LocationId });
        }

		[HttpGet]
        public IActionResult EditExperience(int locationId, int experienceId)
		{
			ExperienceAtLocation model = new ExperienceAtLocation();
			model.Location = db.Locations.FirstOrDefault(location => location.LocationId == locationId);
            Experience thisExperience = db.Experiences.FirstOrDefault((experience => experience.ExperienceId == experienceId));
			model.ExperienceId = experienceId;
            model.ExperienceName = thisExperience.Name;
            model.ExperienceDescription = thisExperience.Description;
			return View(model);
		}

		[HttpPost]
		public IActionResult EditExperience(ExperienceAtLocation formResults)
		{
			Experience newExperience = new Experience();
			newExperience.Name = formResults.ExperienceName;
			newExperience.Description = formResults.ExperienceDescription;
			newExperience.ExperienceId = formResults.ExperienceId;
			newExperience.LocationId = formResults.Location.LocationId;

			db.Entry(newExperience).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Details", "Home", new { id = formResults.Location.LocationId });
		}
    }
}
