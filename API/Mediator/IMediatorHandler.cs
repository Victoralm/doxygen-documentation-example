using doxygen_documentation_example.Messages;
using FluentValidation.Results;

namespace doxygen_documentation_example.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T theEvent) where T : Event;
        Task<ValidationResult> SendCommand<T>(T theCommand) where T : Command;
    }
}
