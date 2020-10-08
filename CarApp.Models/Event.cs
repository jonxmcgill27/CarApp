using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarApp.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public byte[] Image { get; set; }

    }
}
