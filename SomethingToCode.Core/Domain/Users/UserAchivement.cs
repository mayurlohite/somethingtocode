using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Users
{
    public class UserAchivement : BaseEntity
    {
        public long UserAchivementID { get; set; }

        public long UserID { get; set; }

        public string Achivement { get; set; }

        public virtual User User { get; set; }
    }
}