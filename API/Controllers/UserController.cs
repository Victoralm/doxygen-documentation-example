using doxygen_documentation_example.Commands;
using doxygen_documentation_example.Data.Models;
using doxygen_documentation_example.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace doxygen_documentation_example.Controllers
{
    [Route("Api/[controller]/[action]")]
    public class UserController : MainController
    {
        private readonly IMediator _mediator;
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
        public async Task<IActionResult> Add(AddUserCommand addUserCommand)
        {
            //int data = 0;
            //if (user.IsValid().IsValid)
            //{
            //    data = await _usersRepository.AddAsync(user);
            //    return Ok(data);
            //} else
            //{
            //    this.Errors = (ICollection<string>)user.IsValid().Errors;

            //    return data == null ? NotFound() : CustomResponse(data);
            //}
            return CustomResponse(await _mediator.Send(addUserCommand));
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
