
using SomethingToCode.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;
using SomethingToCode.Core.Helpers;
using SomethingToCode.Core.Domain.Masters.Catelog;

namespace SomethingToCode.DbServices.Masters
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoryService : ICategoryService
    {

        #region Fields
        private readonly IRepository<Category> _categoryRepository;
        #endregion

        #region Constructor
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        public void Insert(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            category.UrlSlug = GlobalCommonHelper.GetSlugURLFromString(category.CategoryName);
            Category catSlug = GetCategoryBySlugUrl(category.UrlSlug);
            if (catSlug != null)
                category.UrlSlug = category.UrlSlug + "-" + 1;

            _categoryRepository.Insert(category);
        }

        public void Update(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Update(category);
        }

        public void Delete(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Delete(category);
        }

        public IPagedList<Category> GetAllCategories(int? page, bool? isEnable = true)
        {
            var query = _categoryRepository.Table;

            if (isEnable == true)
                query = query.Where(x => x.IsEnable == true);

            if (isEnable == false)
                query = query.Where(x => x.IsEnable == false);

            return query.OrderByDescending(x => x.CategoryID).ToPagedList(page ?? 1, GlobalCommonHelper.PageSize);
        }

        public IPagedList<Category> GetCategoriesBySearchCriteria(int? page, long? UserID, string categoryName, bool? isEnable = true)
        {
            var query = _categoryRepository.Table;

            if (isEnable == true)
                query = query.Where(x => x.IsEnable == true);

            if (isEnable == false)
                query = query.Where(x => x.IsEnable == false);

            if (UserID != null && UserID != 0)
            {
                query = query.Where(x => x.UserID == UserID);
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(x => x.CategoryName.ToLower().Contains(categoryName.ToLower()));
            }

            return query.OrderByDescending(x => x.CategoryID).ToPagedList(page ?? 1, GlobalCommonHelper.PageSize);
        }

        public IPagedList<Category> GetCategoriesByUserId(int? page, long UserID, bool? isEnable = true)
        {
            var query = _categoryRepository.Table;

            if (UserID != 0)
            {
                query = query.Where(x => x.UserID == UserID);
            }

            if (isEnable == true)
                query = query.Where(x => x.IsEnable == true);

            if (isEnable == false)
                query = query.Where(x => x.IsEnable == false);



            return query.OrderByDescending(x => x.CategoryID).ToPagedList(page ?? 1, GlobalCommonHelper.PageSize);
        }

        public Category GetCategoryById(long CategoryID)
        {
            if (CategoryID == 0)
                return null;

            return _categoryRepository.GetById(CategoryID);
        }

        public Category GetCategoryBySlugUrl(string slugUrl, bool? isEnable = true)
        {
            if (string.IsNullOrEmpty(slugUrl))
                return null;

            var query = _categoryRepository.Table;

            if (isEnable == true)
                query = query.Where(x => x.IsEnable == true);

            if (isEnable == false)
                query = query.Where(x => x.IsEnable == false);

            query = query.Where(x => x.UrlSlug.ToLower() == slugUrl.ToLower());

            return query.SingleOrDefault();
        }


        #endregion

    }
}
