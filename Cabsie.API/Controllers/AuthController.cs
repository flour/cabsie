using AutoMapper;
using Cabsie.API.Models;
using Cabsie.API.Services;
using Cabsie.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cabsie.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public AuthController(
            IAuthService authService,
            IUsersRepository userRepository,
            IMapper mapper
        )
        {
            _authService = authService;
            _usersRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _usersRepository
                .GetItemAsync(u => u.Username == loginVM.Username);
            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            if (!_authService.VerifyPassword(loginVM.Password, user.Password))
            {
                return BadRequest(new { password = "invalid password" });
            }

            return Ok(_authService.GetAuthData(user.Id.ToString()));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var validEmail = await _usersRepository.HasUniqEmailAsync(registerVM.Email);
            if (!validEmail)
            {
                return BadRequest(new { email = "user with this email already exists" });
            }
            var userEntity = _mapper.Map<User>(registerVM);
            userEntity.Password = _authService.HashPassword(userEntity.Password);
            _usersRepository.CreateItem(userEntity);
            if (!await _usersRepository.SaveAsync())
            {
                return StatusCode(500, new { user = "Could not save user" });
            }

            return Ok(_authService.GetAuthData(userEntity.Id.ToString()));
        }
    }
}

