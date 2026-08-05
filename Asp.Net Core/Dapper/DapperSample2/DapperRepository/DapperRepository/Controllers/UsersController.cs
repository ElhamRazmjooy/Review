using DapperRepository.Models;
using DapperRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository repository) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => await _repository.GetByIdAsync(id) == null ? NotFound() : Ok(_repository.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _repository.AddAsync(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _repository.UpdateAsync(user);
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}
