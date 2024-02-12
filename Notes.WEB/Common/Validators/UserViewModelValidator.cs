using FluentValidation;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.WEB.Common.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(s => s.UserName).NotEmpty();
            RuleFor(s => s.Password).NotEmpty().MinimumLength(8);
        }
    }
}
