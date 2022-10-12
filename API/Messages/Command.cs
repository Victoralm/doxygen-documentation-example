using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace doxygen_documentation_example.Messages
{
    public class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
