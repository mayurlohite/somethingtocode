using SomethingToCode.Core.Domain.Masters;
using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Core.Helpers;
using SomethingToCode.DbServices.Masters;
using SomethingToCode.Web.Factories;
using SomethingToCode.Web.Helpers;
using SomethingToCode.Web.Models.Masters.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SomethingToCode.Web.Extensions;

namespace SomethingToCode.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryModelFactory _categoryModelFactory;

        public CategoryController(ICategoryService categoryService,
                                  ICategoryModelFactory categoryModelFactory)
        {
            _categoryService = categoryService;
            _categoryModelFactory = categoryModelFactory;
        }

        #region Utilities



        #endregion

        public ActionResult Index(int? page, string categoryName = "", long userID = 0, bool? IsEnable = null)
        {
            //var model = _categoryModelFactory.PrepareBlogPostListModel(page);
            return View();
        }

        public ActionResult List(int? page, string categoryName = "", long userID = 0, bool? IsEnable = null)
        {
            var model = _categoryModelFactory.PrepareCategoryListModel(page, userID, categoryName, IsEnable);
            return PartialView("_CategorySingleRowPartial", model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            if (model.HttpCategryImage != null && !CommonHelper.IsValidImageFormat(model.HttpCategryImage, 1, 2097152))
            {
                ModelState.AddModelError("HttpCategryImage", "only jpg & png allowed and size must be 2MB or lower.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            Category category = model.ToEntity();
            category.UserID = 1;
            category.Created = DateTime.UtcNow;
            category.CategoryImage = CommonHelper.UploadPicture(model.HttpCategryImage, CommonHelper.CategoryImages);
            _categoryService.Insert(category);

            TempData["message"] = CommonHelper.GenerateMessage("Category Added Successfully", CommonHelper.EnumErrorMessages.SUCCESS);

            return RedirectToAction("Create", "Category");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return RedirectToAction("Index");

            var model = category.ToModel();

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel model, int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            category = model.ToEntity(category);
            category.Modified = DateTime.UtcNow;
            _categoryService.Update(category);

            TempData["message"] = CommonHelper.GenerateMessage("Category Updated Successfully", CommonHelper.EnumErrorMessages.SUCCESS);

            return RedirectToAction("Create", "Category");
        }

        [HttpPost]
        public ActionResult Delete(long id = 0)
        {

            return View();
        }



    }
}