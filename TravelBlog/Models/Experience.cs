﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
	[Table("Experiences")]
	public class Experience
	{
		[Key]
		public int ExperienceId { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
		public int LocationId { get; set; }
        public virtual Location Location { get; set; }
	}
}
