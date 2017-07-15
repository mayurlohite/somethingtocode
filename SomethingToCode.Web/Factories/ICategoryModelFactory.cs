
using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Web.Models.Masters.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingToCode.Web.Factories
{
    public partial interface ICategoryModelFactory
    {
        CategoryListModel PrepareCategoryListModel(int? page, long userID = 0, string categoryName = "", bool? IsEnable = null);
        void PrepareCategoryModel(CategoryModel model, Category category);
    }
}
