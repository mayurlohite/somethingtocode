using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsEnable = true;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
        public bool IsEnable { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
