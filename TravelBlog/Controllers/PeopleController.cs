using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TravelBlog.Models;
using TravelBlog.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PeopleController : Controller
    {
		private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult Add(int locationId)
        {
			PersonAtLocation model = new PersonAtLocation();
            model.Location = db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);

			return View(model);
        }

        [HttpPost]
        public IActionResult Add(PersonAtLocation formResults)
        {
            Person newPerson = new Person();
            newPerson.Name = formResults.PersonName;
            newPerson.LocationId = formResults.Location.LocationId;

            db.People.Add(newPerson);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
