using doxygen_documentation_example.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace doxygen_documentation_example.Controllers
{
    [Route("Api/[controller]/[action]")]
    public class UserController : MainController
    {
        private readonly IUserRepository _usersRepository;

        public UserController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = this._usersRepository.GetAllUsers();
            return users == null ? NotFound() : CustomResponse(users);
        }
    }
}
