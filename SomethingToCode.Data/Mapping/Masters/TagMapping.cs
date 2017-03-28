using SomethingToCode.Core.Domain.Masters;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Masters
{
    public class TagMapping : EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            ToTable("Tags");
            HasKey(t => t.TagID);
            Property(t => t.TagName).IsRequired().HasMaxLength(155);
            Property(t => t.Description).HasMaxLength(255);

            HasRequired(t => t.User)
                .WithMany(u => u.Tags)
                .HasForeignKey(t => t.UserID);
        }
    }
}
