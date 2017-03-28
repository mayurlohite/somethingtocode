using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SomethingToCode.Core.Domain.Users
{
    public class UserEducation : BaseEntity
    {
      
        public long UserEducationID { get; set; }

        public long UserID { get; set; }

        public string SchoolName { get; set; }

        public string Degree { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public bool Stilllearning { get; set; }

        public virtual User User { get; set; }
    }
}