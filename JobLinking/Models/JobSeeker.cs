using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobLinking.Models
{
    public class JobSeeker
    {
        public JobSeeker() 
        {
            JobAdvertisements = new List<JobAdvertisement>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string EducationLevel { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string About { get; set; }
        public virtual List<JobAdvertisement> JobAdvertisements { get; set; }
        public string UserIdRelation { get; set; }
    }
}