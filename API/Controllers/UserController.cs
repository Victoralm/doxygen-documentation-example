using doxygen_documentation_example.Data.Models;
using doxygen_documentation_example.Data.Repositories;
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
        public async Task<IActionResult> PopulateDb()
        {
            var users = _usersRepository.PopulateDb();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _usersRepository.GetAllAsync();
            return data == null ? NotFound() : CustomResponse(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _usersRepository.GetByIdAsync(id);
            return data == null ? NotFound() : CustomResponse(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(User users)
        {
            var data = await _usersRepository.AddAsync(users);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _usersRepository.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var data = await _usersRepository.UpdateAsync(user);
            return Ok(data);
        }
    }
}
