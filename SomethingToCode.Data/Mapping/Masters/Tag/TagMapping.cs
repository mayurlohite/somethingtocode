using SomethingToCode.Core.Domain.Articles;
using SomethingToCode.Core.Domain.Masters.Tag;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Masters.Tag
{
    public class TagMapping : EntityTypeConfiguration<SomethingToCode.Core.Domain.Masters.Tag.Tag>
    {
        public TagMapping()
        {
            ToTable("Tags");
            HasKey(t => t.TagID);
            Property(t => t.TagName).IsRequired().HasMaxLength(155);
            Property(t => t.Description).HasMaxLength(255);

            HasRequired(t => t.User)
                .WithMany(u => u.Tags)
                .HasForeignKey(t => t.UserID)
                .WillCascadeOnDelete(false);

            HasMany<Article>(a => a.Articles)
             .WithMany(t => t.Tags)
              .Map(ac =>
              {
                  ac.MapLeftKey("TagID");
                  ac.MapRightKey("ArticleID");
                  ac.ToTable("ArticleTags");
              });
        }
    }
}
