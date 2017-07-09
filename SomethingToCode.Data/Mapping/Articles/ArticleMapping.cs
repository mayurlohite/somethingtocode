using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Core.Domain.Masters.Tag;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Articles
{
    public class ArticleMapping : EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            ToTable("Articles");
            HasKey(a => a.ArticleID);
            Property(a => a.ArticleTitle).IsRequired().HasMaxLength(155);
            Property(a => a.ShortDescription).IsRequired().HasMaxLength(255);
            Property(a => a.UrlSlug).IsRequired().HasMaxLength(155);
            Property(a => a.LongDescription).IsMaxLength();

            HasRequired(a => a.User)
               .WithMany(u => u.Articles)
               .HasForeignKey(a => a.UserID);

           
            HasMany<Category>(c => c.Categories)
                .WithMany(a => a.Articles)
                .Map(ac =>
                {
                    ac.MapLeftKey("ArticleID");
                    ac.MapRightKey("CategoryID");
                    ac.ToTable("ArticleCategories");
                });

            HasMany<Tag>(t => t.Tags)
               .WithMany(a => a.Articles)
               .Map(ac =>
               {
                   ac.MapLeftKey("ArticleID");
                   ac.MapRightKey("TagID");
                   ac.ToTable("ArticleTags");
               });
        }
    }
}
