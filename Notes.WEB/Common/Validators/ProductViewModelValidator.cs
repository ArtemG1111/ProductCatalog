using FluentValidation;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.WEB.Common.Validators
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Description).MaximumLength(120);
            RuleFor(s => s.Price).NotEmpty();
        }
    }
}
