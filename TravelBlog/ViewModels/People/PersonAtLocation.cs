using System;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
    public class PersonAtLocation
    {
        public string PersonName { get; set; } = null;
        public Location Location { get; set; } = null;

		public PersonAtLocation()
        {
        }
    }
}
