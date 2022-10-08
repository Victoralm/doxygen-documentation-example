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

        protected IActionResult CustomResponse(object result = null)
        {
            if(ValidOperation() && result != null) return Ok(result);
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages: ", Errors.ToArray() }
            }));
        }
    }
}
