using System;
namespace QuadrantsProject.Models
{
    public class EmptyClass
    {
        //constructor
        public QuadrantApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //leave blank
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
