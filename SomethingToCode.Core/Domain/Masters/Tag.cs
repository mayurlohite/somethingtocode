﻿using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Masters
{
    public class Tag:BaseEntity
    {
        [Key]
        public long TagID { get; set; }

        public long UserID { get; set; }

        public string TagName  { get; set; }
                
        [StringLength(255)]
        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}