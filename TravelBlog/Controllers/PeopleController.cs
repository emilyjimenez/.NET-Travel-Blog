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
    public class PeopleController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult AddToLocation(int locationId)
        {
            PersonAtLocation model = new PersonAtLocation();
            model.Location = db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToLocation(PersonAtLocation formResults)
        {
            Person newPerson = new Person();
            newPerson.Name = formResults.PersonName;
            newPerson.LocationId = formResults.Location.LocationId;

            db.People.Add(newPerson);
            db.SaveChanges();
            return RedirectToAction("Details", "Home", new { id = formResults.Location.LocationId });
        }

        [HttpGet]
        public IActionResult DeletePerson(int personId)
        {
            var thisPerson = db.People.FirstOrDefault(people => people.PersonId == personId);
            db.People.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Details", "Home", new { id = thisPerson.LocationId });
        }

        [HttpGet]
        public IActionResult EditPerson(int locationId, int personId)
        {
            PersonAtLocation model = new PersonAtLocation();
            model.Location = db.Locations.FirstOrDefault(location => location.LocationId == locationId);
            Person thisPerson = db.People.FirstOrDefault(person => person.PersonId == personId);
            model.PersonId = thisPerson.PersonId;
            model.PersonName = thisPerson.Name;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPerson(PersonAtLocation formResults)
        {
			Person newPerson = new Person();
			newPerson.Name = formResults.PersonName;
            newPerson.PersonId = formResults.PersonId;
			newPerson.LocationId = formResults.Location.LocationId;

			db.Entry(newPerson).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Home", new { id = formResults.Location.LocationId});
        }
    }
}