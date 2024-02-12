using FluentValidation;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.WEB.Common.Validators
{
    public class CategoryViewModelValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryViewModelValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}
