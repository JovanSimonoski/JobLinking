using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobLinking.Models
{
    public class JobAdvertisement
    {
        public JobAdvertisement()
        {
            JobSeekers = new List<JobSeeker>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        public Job Job { get; set; }
        [Required]
        public int JobId { get; set; }
        public Company Company { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public virtual List<JobSeeker> JobSeekers { get; set; }
        public string JobTitle{ get; set; }
    }
}