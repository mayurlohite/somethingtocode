using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Users
{
    public class UserAchivementMapping : EntityTypeConfiguration<UserAchivement>
    {
        public UserAchivementMapping()
        {
            ToTable("UserAchivements");
            HasKey(ua => ua.UserAchivementID);
            Property(ua => ua.Achivement).IsRequired().HasMaxLength(255);

            HasRequired(ua => ua.User)
                .WithMany(u => u.UserAchivements)
                .HasForeignKey(ua => ua.UserID);
        }
    }
}
