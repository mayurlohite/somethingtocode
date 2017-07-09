using PagedList;
using SomethingToCode.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Models.Masters.Category
{
    public class CategoryListModel
    {
       
        public IList<CategoryModel> Categories { get; set; }
        public Pager Pager { get; set; }
    }
}