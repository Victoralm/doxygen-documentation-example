using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace doxygen_documentation_example.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddProcessingError(string error)
        {
            Errors.Add(error);
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if(ValidOperation() && result != null) return Ok(result);
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages2: ", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            if (validationResult != null)
                foreach (var error in validationResult.Errors)
                    AddProcessingError(error.ErrorMessage);

            return CustomResponse();
        }
    }
}
