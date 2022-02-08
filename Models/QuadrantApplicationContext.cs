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
        public DbSet<Category> Category { get; set; }

    }
}
