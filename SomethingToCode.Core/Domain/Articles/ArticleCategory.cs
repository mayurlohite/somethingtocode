using SomethingToCode.Core.Domain.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Articles
{
    public class ArticleCategory : BaseEntity
    {
        public long ArticleCategoryID { get; set; }

        public long ArticleID { get; set; }

        public long CategoryID { get; set; }

        public virtual Article Article { get; set; }

        public virtual Category Category { get; set; }
    }
}