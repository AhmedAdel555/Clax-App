using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using calx.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace calx.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Make { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [StringLength(100)]
        public string Color { get; set; }

        [Required]
        [Range(1950, 2023)]
        public int Year { get; set; }

        [Required]
        [Url]
        public string ImgUrl { get; set; }

        [Required]
        [Range(50000, 5000000)]
        public double Price { get; set; }

        public Transmission Transmission { get; set; }

        [Display(Name = "Transmission")]
        [Required]
        public int TransmissionId { get; set; }

        public CarStyle CarStyle { get; set; }

        [Display(Name = "Car Style")]
        [Required]
        public int CarStyleId { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Car()
        {

        }
    }
}
