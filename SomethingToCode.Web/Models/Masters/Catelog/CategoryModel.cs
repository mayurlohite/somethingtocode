using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Models.Masters.Category
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public bool IsEnable { get; set; }

        public DateTime Created { get; set; }
    }
}