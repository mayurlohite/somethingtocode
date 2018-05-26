
using SomethingToCode.Core.Domain.Masters;
using SomethingToCode.Core.Domain.Masters.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Articles
{
    public class ArticleTag:BaseEntity
    {
        
        public long ArticleTagID { get; set; }

        public long ArticleID { get; set; }

        public long TagID { get; set; }

        public virtual Article Article { get; set; }

        public virtual Tag Tag { get; set; }

     
    }
}