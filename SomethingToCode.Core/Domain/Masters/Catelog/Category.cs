using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Masters.Catelog
{

    public class Category : BaseEntity
    {
       
        private ICollection<Article> _articles;

        public int CategoryID { get; set; }

        public long UserID { get; set; }
       
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string UrlSlug { get; set; }

        public string CategoryImage { get; set; }

        public virtual User User { get; set; }


        public virtual ICollection<Article> Articles
        {
            get { return _articles ?? (_articles = new List<Article>()); }
            protected set { _articles = value; }
        }
    }
}