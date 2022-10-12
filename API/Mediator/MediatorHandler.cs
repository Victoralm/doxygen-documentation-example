using doxygen_documentation_example.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace doxygen_documentation_example.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T theEvent) where T : Event
        {
            await _mediator.Publish(theEvent);
        }

        public async Task<ValidationResult> SendCommand<T>(T theCommand) where T : Command
        {
            return await _mediator.Send(theCommand);
        }
    }
}