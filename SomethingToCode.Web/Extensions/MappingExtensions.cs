using SomethingToCode.Core.Domain.Masters.Catelog;
using SomethingToCode.Web.Models.Masters.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Extensions
{
    public static class MappingExtensions
    {
        //categories
        public static CategoryModel ToModel(this Category entity)
        {
            CategoryModel cm = new CategoryModel();
            cm.CategoryID = entity.CategoryID;
            cm.CategoryName = entity.CategoryName;
            cm.Description = entity.Description;
            cm.IsEnable = entity.IsEnable;
            cm.Created = entity.Created;
            cm.CategoryImage = entity.CategoryImage;
            return cm;
        }

        public static Category ToEntity(this CategoryModel model)
        {
            Category c = new Category();
            c.CategoryID = model.CategoryID;
            c.CategoryName = model.CategoryName;
            c.Description = model.Description;
            c.IsEnable = model.IsEnable;
            c.Created = model.Created;
            c.CategoryImage = model.CategoryImage;
            return c;
        }

        public static Category ToEntity(this CategoryModel model, Category c)
        {
            c.CategoryID = model.CategoryID;
            c.CategoryName = model.CategoryName;
            c.Description = model.Description;
            c.IsEnable = model.IsEnable;
            c.Created = model.Created;
            c.CategoryImage = model.CategoryImage;
            return c;
        }
    }
}