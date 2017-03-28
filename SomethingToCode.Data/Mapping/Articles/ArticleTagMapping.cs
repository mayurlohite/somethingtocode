using SomethingToCode.Core.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Articles
{
    class ArticleTagMapping : EntityTypeConfiguration<ArticleTag>
    {
        public ArticleTagMapping()
        {
            ToTable("ArticleTags");
            HasKey(at => at.ArticleTagID);

            HasRequired(at => at.Article)
               .WithMany(a => a.ArticleTags)
               .HasForeignKey(at => at.ArticleID);

            HasRequired(at => at.Tag)
              .WithMany(t => t.ArticleTags)
              .HasForeignKey(at => at.TagID);
        }
    }
}
