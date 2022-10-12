using doxygen_documentation_example.Commands;
using doxygen_documentation_example.Data.Models;
using doxygen_documentation_example.Data.Repositories;
using doxygen_documentation_example.Messages;
using FluentValidation.Results;
using MediatR;

namespace doxygen_documentation_example.CommandHandlers
{
    public class AddUserCommandHandler : CommandHandler, IRequestHandler<AddUserCommand, ValidationResult>
    {
        private readonly IUserRepository _repository;

        public AddUserCommandHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;

            var user = new User(command.Name, command.Email, command.WebSite, command.Followers, command.Area, command.Bio);

            await _repository.AddAsync(user);

            return ValidationResult;
        }
    }
}
