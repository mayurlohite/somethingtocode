using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Users
{
    public class UserSkill : BaseEntity
    {
        [Key]
        public long UserSkillID { get; set; }

        public long UserID { get; set; }
       
        public string SkillName { get; set; }

        public decimal SkillExpert { get; set; }

        public virtual User User { get; set; }
    }
}