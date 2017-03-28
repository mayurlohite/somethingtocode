using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Articles
{
    public class ArticleComment : BaseEntity
    {
        
        public long CommentID { get; set; }

        public long ArticleID { get; set; }

        public long UserID { get; set; }

        public string CommentDetails { get; set; }

        public virtual User User { get; set; }

        public virtual Article Article { get; set; }


    }
}