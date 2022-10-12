using doxygen_documentation_example.Messages;
using FluentValidation;

namespace doxygen_documentation_example.Commands
{
    public class AddUserCommand : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public long Followers { get; set; }
        public string Area { get; set; }
        public string Bio { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AddUserCommandValidation : AbstractValidator<AddUserCommand>
        {
            public AddUserCommandValidation()
            {
                RuleFor(user => user.Name).NotNull().NotEmpty().Length(1, 500);
                RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress().Length(1, 500);
                RuleFor(user => user.WebSite).NotNull().NotEmpty();
                RuleFor(user => user.Followers).NotNull().NotEmpty().InclusiveBetween(0, 100000000000);
                RuleFor(user => user.Area).NotNull().NotEmpty();
                RuleFor(user => user.Bio).NotNull().NotEmpty();
            }
        }
    }
}
