using SomethingToCode.Core.Domain.Masters;
using SomethingToCode.Core.Helpers;
using SomethingToCode.DbServices.Masters;
using SomethingToCode.Web.Factories;
using SomethingToCode.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Index(int? page, string categoryName = "", long userID = 0, bool? IsEnable = null)
        {
            //var model = _categoryModelFactory.PrepareBlogPostListModel(page);
            return View();
        }

        public ActionResult List(int? page, string categoryName = "", long userID = 0, bool? IsEnable = null)
        {
            var model = _categoryModelFactory.PrepareBlogPostListModel(page);
            return PartialView("_CategorySingleRowPartial", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id=0)
        {
           

            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id = 0)
        {
           

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Delete(long id = 0)
        {
           
            return View();
        }



    }
}