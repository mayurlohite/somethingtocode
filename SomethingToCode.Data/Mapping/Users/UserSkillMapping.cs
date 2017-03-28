using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Users
{
    public class UserSkillMapping : EntityTypeConfiguration<UserSkill>
    {
        public UserSkillMapping()
        {
            ToTable("UserSkills");
            HasKey(us => us.UserSkillID);
            Property(us => us.SkillName).IsRequired().HasMaxLength(100);
            Property(us => us.SkillExpert).HasPrecision(5, 2);

            HasRequired(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserID);
        }
    }
}
