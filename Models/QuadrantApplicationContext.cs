using System;
using Microsoft.EntityFrameworkCore;

namespace QuadrantsProject.Models
{
    public class QuadrantApplicationContext: DbContext
    {
        //constructor
        public QuadrantApplicationContext(DbContextOptions<QuadrantApplicationContext> options) : base(options)
        {
            //leave blank
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "Work" },
                new Category { CategoryID = 3, CategoryName = "School" },
                new Category { CategoryID = 4, CategoryName = "Church" }

                );
            mb.Entity<ApplicationResponse>().HasData(
                 new ApplicationResponse
                 {
                     TaskID = 1,
                     CategoryID = 1,
                     Task = "dishes",
                     DueDate = "tomorrow",
                     Quadrant = "Urgent",
                     Completed = false

                 },
                new ApplicationResponse
                 {
                     TaskID = 2,
                     CategoryID = 1,
                     Task = "take out trash",
                     DueDate = "tomorrow",
                     Quadrant = "Urgent",
                     Completed = false

                 },
                 new ApplicationResponse
                 {
                     TaskID = 3,
                     CategoryID = 1,
                     Task = "clean",
                     DueDate = "tomorrow",
                     Quadrant = "Urgent",
                     Completed = false
                 }
                 );
        }

        }
}
