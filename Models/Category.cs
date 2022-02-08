using System;
using System.ComponentModel.DataAnnotations;

namespace QuadrantsProject.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
