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
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage(" is required.").Length(2, 255)
                .WithMessage(" must be minimum 2 character and maximum 255 character.");

            RuleFor(c => c.Description).NotEmpty().WithMessage(" is required.").Length(2, 355)
                .WithMessage(" must be minimum 2 character and maximum 355 character.");
        }
    }
}