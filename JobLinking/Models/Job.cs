using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobLinking.Models
{
    public class Job
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}