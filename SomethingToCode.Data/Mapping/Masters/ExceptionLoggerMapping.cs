using SomethingToCode.Core.Domain.Masters;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Data.Mapping.Masters
{
    public class ExceptionLoggerMapping : EntityTypeConfiguration<ExceptionLogger>
    {
        public ExceptionLoggerMapping()
        {
            ToTable("ExceptionLoggers");
            HasKey(el => el.Id);
            Property(el => el.InnerException).HasMaxLength(255);
            Property(el => el.ExceptionMessage).HasMaxLength(255);
            Property(el => el.Source).HasMaxLength(100);
            Property(el => el.ExceptionStackTrace).IsMaxLength();
            Property(el => el.ControllerName).HasMaxLength(100);
            Property(el => el.ActionName).HasMaxLength(60);
        }
    }
}
