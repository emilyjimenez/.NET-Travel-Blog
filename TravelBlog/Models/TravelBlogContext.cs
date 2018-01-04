using System;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class TravelBlogContext : DbContext
    {
		public DbSet<Location> Locations { get; set; }
		public DbSet<Person> People { get; set; }
		public DbSet<Experience> Experiences { get; set; }

        public TravelBlogContext()
        {
        }

		public TravelBlogContext(DbContextOptions<TravelBlogContext> options)
            : base(options)
        {
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=8889;database=travelblog;uid=root;pwd=root;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
