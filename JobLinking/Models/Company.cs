using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobLinking.Models
{
    public class Company
    {
        public Company() 
        {
            JobAdvertisements = new List<JobAdvertisement>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string About { get; set; }
        public virtual List<JobAdvertisement> JobAdvertisements { get; set; }
        public string UserIdRelation { get; set; }
    }
}