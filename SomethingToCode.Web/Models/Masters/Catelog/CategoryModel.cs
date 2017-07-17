using FluentValidation.Attributes;
using SomethingToCode.Web.Validators.Masters.Catelog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Models.Masters.Category
{
    [Validator(typeof(CategoryModelValidator))]
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public bool IsEnable { get; set; }

        public HttpPostedFileBase HttpCategryImage { get; set; }

        public DateTime Created { get; set; }
    }
}