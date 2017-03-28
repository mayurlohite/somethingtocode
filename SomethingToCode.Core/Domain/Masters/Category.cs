using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Masters
{

    public class Category : BaseEntity
    {
        private ICollection<ArticleCategory> _articleCategories;

        public long CategoryID { get; set; }

        public long UserID { get; set; }
       
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string UrlSlug { get; set; }

        public virtual User user { get; set; }


        public virtual ICollection<ArticleCategory> ArticleCategories
        {
            get { return _articleCategories ?? (_articleCategories = new List<ArticleCategory>()); }
            protected set { _articleCategories = value; }
        }
    }
}