using SomethingToCode.Core.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Articles
{
    public class ArticleCategoryMapping : EntityTypeConfiguration<ArticleCategory>
    {
        public ArticleCategoryMapping()
        {
            ToTable("ArticleCategories");
            HasKey(ac => ac.ArticleCategoryID);

            HasRequired(ac => ac.Article)
               .WithMany(a => a.ArticleCategories)
               .HasForeignKey(ac => ac.ArticleID);

            HasRequired(ac => ac.Category)
              .WithMany(c => c.ArticleCategories)
              .HasForeignKey(ac => ac.CategoryID);
        }
    }
}
