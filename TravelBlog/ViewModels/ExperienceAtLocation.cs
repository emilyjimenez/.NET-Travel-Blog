using System;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
    public class ExperienceAtLocation
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; } = null;
		public string ExperienceDescription { get; set; } = null;
		public Location Location { get; set; } = null;

		public ExperienceAtLocation()
        {
        }
    }
}
