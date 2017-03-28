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

        private ICollection<ArticleTag> _articleTags { get; set; }
        private ICollection<ArticleComment> _articleComments { get; set; }
        private ICollection<ArticleCategory> _articleCategories { get; set; }


        public long ArticleID { get; set; }

        public long UserID { get; set; }

        public string ArticleTitle { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public bool IsApproved { get; set; }

        public string UrlSlug { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags
        {
            get { return _articleTags ?? (_articleTags = new List<ArticleTag>()); }
            protected set { _articleTags = value; }
        }

        public virtual ICollection<ArticleComment> ArticleComments
        {
            get { return _articleComments ?? (_articleComments = new List<ArticleComment>()); }
            protected set { _articleComments = value; }
        }

        public virtual ICollection<ArticleCategory> ArticleCategories
        {
            get { return _articleCategories ?? (_articleCategories = new List<ArticleCategory>()); }
            protected set { _articleCategories = value; }
        }
    }
}