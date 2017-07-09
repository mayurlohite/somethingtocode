using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Core.Domain.Masters.Tag;
using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Articles
{
    public class Article : BaseEntity
    {

        private ICollection<Tag> _tags { get; set; }
        private ICollection<ArticleComment> _articleComments { get; set; }
        private ICollection<Category> _categories { get; set; }


        public long ArticleID { get; set; }

        public long UserID { get; set; }

        public string ArticleTitle { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public bool IsApproved { get; set; }

        public string UrlSlug { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return _tags ?? (_tags = new List<Tag>()); }
            protected set { _tags = value; }
        }

        public virtual ICollection<ArticleComment> ArticleComments
        {
            get { return _articleComments ?? (_articleComments = new List<ArticleComment>()); }
            protected set { _articleComments = value; }
        }

        public virtual ICollection<Category> Categories
        {
            get { return _categories ?? (_categories = new List<Category>()); }
            protected set { _categories = value; }
        }
    }
}