using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarApp.Models
{
    public class EventGatheringVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime DateEnd { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public string ImageFormatted { get; set; }
    }
}
