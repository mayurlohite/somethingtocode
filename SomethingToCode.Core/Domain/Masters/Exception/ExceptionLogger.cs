using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SomethingToCode.Core.Domain.Masters.Exception
{
    [Table("ExceptionLogger")]
    public class ExceptionLogger : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string InnerException { get; set; }
        public string ExceptionMessage { get; set; }
        public string Source { get; set; }
        public string ExceptionStackTrace { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

    }
}