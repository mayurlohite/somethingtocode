using FluentValidation;
using SomethingToCode.Web.Models.Masters.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Validators.Masters.Catelog
{
    public class CategoryModelValidator : AbstractValidator<CategoryModel>
    {
        public CategoryModelValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().Length(1, 255)
                .WithMessage("Enter Category");

            RuleFor(c => c.Description).NotEmpty().Length(1, 355)
                .WithMessage("Enter Description");
        }
    }
}