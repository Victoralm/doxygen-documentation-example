using doxygen_documentation_example.Data.Models;
using FluentValidation;
using FluentValidation.Results;

namespace doxygen_documentation_example.Validators
{
    /// <summary>
    /// A FluentValidation validator for objects of type User
    /// </summary>
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotNull().NotEmpty().Length(1, 500);
            RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress().Length(1, 500);
            RuleFor(user => user.WebSite).NotNull().NotEmpty();
            RuleFor(user => user.Followers).NotNull().NotEmpty().InclusiveBetween(0, 100000000000);
            RuleFor(user => user.Area).NotNull().NotEmpty();
            RuleFor(user => user.Bio).NotNull().NotEmpty();
        }

        internal ValidationResult Validate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
