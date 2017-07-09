using SomethingToCode.Core.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Articles
{
    public class ArticleCommentMapping : EntityTypeConfiguration<ArticleComment>
    {
        public ArticleCommentMapping()
        {
            ToTable("ArticleComments");
            HasKey(ac => ac.CommentID);
            Property(ac => ac.CommentDetails).IsMaxLength();


            HasRequired(ac => ac.User)
               .WithMany(u => u.ArticleComments)
               .HasForeignKey(ac => ac.UserID)
               .WillCascadeOnDelete(false);
              

            HasRequired(ac => ac.Article)
              .WithMany(a => a.ArticleComments)
              .HasForeignKey(ac => ac.ArticleID);
        }
    }
}
