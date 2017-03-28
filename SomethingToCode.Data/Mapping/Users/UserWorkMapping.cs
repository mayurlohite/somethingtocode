using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Users
{
    public class UserWorkMapping : EntityTypeConfiguration<UserWork>
    {
        public UserWorkMapping()
        {
            ToTable("UserWorks");
            HasKey(uw => uw.UserWorkID);
            Property(ue => ue.CompanyName).IsRequired().HasMaxLength(255);
            Property(ue => ue.Designation).IsRequired().HasMaxLength(100);
            Property(ue => ue.Description).IsRequired().HasMaxLength(350);

            HasRequired(uw => uw.User)
                .WithMany(u => u.UserWorks)
                .HasForeignKey(uw => uw.UserID);
        }
    }
}
