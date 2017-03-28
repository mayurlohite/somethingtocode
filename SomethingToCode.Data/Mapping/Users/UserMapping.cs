using SomethingToCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Users
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("Users");
            HasKey(x => x.UserID);
            Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            Property(x => x.LastName).IsRequired().HasMaxLength(255);
            Property(x => x.Email).IsRequired().HasMaxLength(255);
            Property(x => x.Password).IsRequired().HasMaxLength(70);
            Property(x => x.Role).HasMaxLength(20);
            Property(x => x.Website).HasMaxLength(100);
            Property(x => x.StatusMessage).HasMaxLength(255);
            Property(x => x.avtar).HasMaxLength(70);
            Property(x => x.Hash).HasMaxLength(70);
            Property(x => x.Gender).HasMaxLength(10);
        }
    }
}
