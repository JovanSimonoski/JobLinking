using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobLinking.Models
{
    public class UserCompanyRelationModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
    }
}