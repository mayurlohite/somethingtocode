using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SomethingToCode.Core.Domain.Users
{
    public class UserWork : BaseEntity
    {
        [Key]
        public long UserWorkID { get; set; }

        public long UserID { get; set; }
        
        [StringLength(255)]

        [Required(ErrorMessage = "Enter Company Name")]
        public string CompanyName { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Enter Designation ")]
        public string Designation { get; set; }

        
        
        public DateTime StartDate { get; set; }

        
        public DateTime? EndDate { get; set; }

        [StringLength(255)]        
        public string Description { get; set; }

       
        public bool StillWorking { get; set; }

        public virtual User User { get; set; }
    }
}