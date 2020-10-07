using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarApp.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public byte[] Picture { get; set; }
    }
}
