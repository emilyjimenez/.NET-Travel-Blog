using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
	[Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
		public virtual ICollection<Experience> Experiences { get; set; }

        public Location()
        {
            this.People = new HashSet<Person>();
			this.Experiences = new HashSet<Experience>();
		}
	}
}
