using AutoMapper;
using Cabsie.API.Entities;
using Cabsie.API.Models;
using Cabsie.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cabsie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _repository.GetItemsAsync(0, 0);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            var entity = await _repository.GetItemAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserVM>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserVM user)
        {
            var entity = _mapper.Map<UserVM, User>(user);
            _repository.CreateItem(entity);
            await _repository.SaveAsync();
            await _repository.GetItemAsync(entity.Id);

            return CreatedAtRoute(
                "GetUserById",
                new { id = entity.Id },
                _mapper.Map<User, UserVM>(entity)
            );
        }
    }
}
