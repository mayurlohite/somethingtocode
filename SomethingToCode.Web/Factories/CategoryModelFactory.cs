using PagedList;
using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.DbServices.Masters;
using SomethingToCode.Web.Helpers;
using SomethingToCode.Web.Models.Masters.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Factories
{
    public partial class CategoryModelFactory : ICategoryModelFactory
    {
        private readonly ICategoryService _categoryService;

        public CategoryModelFactory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public CategoryListModel PrepareBlogPostListModel(int? page)
        {

            var model = new CategoryListModel();

            IPagedList<Category> categories = _categoryService.GetAllCategories(page);

            model.Categories = categories
                .Select(x =>
                {
                    var categoryModel = new CategoryModel();
                    PrepareBlogPostModel(categoryModel, x);
                    return categoryModel;
                }).ToList();

            model.Pager =  new Pager(categories.TotalItemCount, page);

            return model;
        }

        public void PrepareBlogPostModel(CategoryModel model, Category category)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (category == null)
                throw new ArgumentNullException("category");

            model.CategoryID = category.CategoryID;
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;
            model.IsEnable = category.IsEnable;
            model.Created = category.Created;            
        }

    }
}