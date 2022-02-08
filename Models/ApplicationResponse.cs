﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuadrantsProject.Models
{
    public class ApplicationResponse
    {
        [Required]
        [Key]
        private int TaskID { get; set; }

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }

        [Required]
        public string Quadrant { get; set; }

        public bool Completed { get; set; }

        //Build the foreign key relationship
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

