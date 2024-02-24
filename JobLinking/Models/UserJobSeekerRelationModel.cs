using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobLinking.Models
{
    public class UserJobSeekerRelationModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int JobSeekerId { get; set; }
    }
}