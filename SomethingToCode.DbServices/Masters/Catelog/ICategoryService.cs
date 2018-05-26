using SomethingToCode.Core.Domain.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SomethingToCode.Core.Domain.Masters.Catelog;

namespace SomethingToCode.DbServices.Masters
{
    public interface ICategoryService
    {
        void Insert(Category category);

        void Update(Category categories);

        void Delete(Category categories);

        Category GetCategoryById(long CategoryID);

        Category GetCategoryBySlugUrl(string slugUrl, bool? isEnable = true);

        IPagedList<Category> GetAllCategories(int? page, bool? isEnable = true );

        IPagedList<Category> GetCategoriesByUserId(int? page, long UserID, bool? isEnable = true);

        IPagedList<Category> GetCategoriesBySearchCriteria(int? page, long? UserID, string categoryName, bool? isEnable = true);

    }
}
