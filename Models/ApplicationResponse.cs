using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuadrantsProject.Models
{
    public class ApplicationResponse
    {
        [Required]
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public bool Completed { get; set; }

        //Build the foreign key relationship
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}

