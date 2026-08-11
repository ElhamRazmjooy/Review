using Microsoft.AspNetCore.Mvc;
using IdentitySample.Dtos;
using IdentitySample.Services;

namespace IdentitySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserService userService, TokenService tokenService) : ControllerBase
    {
        private readonly UserService _userService = userService;
        private readonly TokenService _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userService.ValidateUser(dto.Username, dto.Password);
            if (user == null)
                return Unauthorized();

            var accessToken = _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            return Ok(new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
