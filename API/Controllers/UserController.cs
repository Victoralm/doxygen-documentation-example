using doxygen_documentation_example.Data.Models;
using doxygen_documentation_example.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace doxygen_documentation_example.Controllers
{
    [Route("Api/[controller]/[action]")]
    public class UserController : MainController
    {
        //private readonly IUserRepository _usersRepository;
        private readonly IUnitOfWork unitOfWork;

        //public UserController(IUserRepository usersRepository)
        public UserController(IUnitOfWork unitOfWork)
        {
            //_usersRepository = usersRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> PopulateDb()
        {
            var users = unitOfWork.Users.PopulateDb();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Users.GetAllAsync();
            //return Ok(data);
            return data == null ? NotFound() : CustomResponse(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await unitOfWork.Users.GetByIdAsync(id);
            //if (data == null) return Ok();
            //return Ok(data);
            return data == null ? NotFound() : CustomResponse(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(User users)
        {
            var data = await unitOfWork.Users.AddAsync(users);
            //return Ok(data);
            return data == null ? NotFound() : CustomResponse(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await unitOfWork.Users.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var data = await unitOfWork.Users.UpdateAsync(user);
            return Ok(data);
        }
    }
}
