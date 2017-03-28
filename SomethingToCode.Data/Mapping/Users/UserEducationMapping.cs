using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Users
{
    public class UserEducationMapping : EntityTypeConfiguration<UserEducation>
    {
        public UserEducationMapping()
        {
            ToTable("UserEducations");
            HasKey(ue => ue.UserEducationID);
            Property(ue => ue.SchoolName).IsRequired().HasMaxLength(255);
            Property(ue => ue.Degree).IsRequired().HasMaxLength(100);
            Property(ue => ue.Description).IsRequired().HasMaxLength(350);

            HasRequired(ue => ue.User)
                .WithMany(u => u.UserEducations)
                .HasForeignKey(ue => ue.UserID);
        }
    }
}
