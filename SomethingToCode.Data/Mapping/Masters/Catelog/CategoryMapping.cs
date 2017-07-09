using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Masters.Catelog;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Masters.Catelog
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Categories");
            HasKey(c => c.CategoryID);
            Property(c => c.CategoryName).IsRequired().HasMaxLength(155);
            Property(c => c.UrlSlug).IsRequired().HasMaxLength(155);
            Property(c => c.Description).IsRequired().HasMaxLength(255);

            HasRequired(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserID)
                .WillCascadeOnDelete(false);

            HasMany<Article>(a => a.Articles)
               .WithMany(c => c.Categories)
                .Map(ac =>
                {
                    ac.MapLeftKey("CategoryID"); 
                    ac.MapRightKey("ArticleID");
                    ac.ToTable("ArticleCategories");
                });



        }
    }
}
