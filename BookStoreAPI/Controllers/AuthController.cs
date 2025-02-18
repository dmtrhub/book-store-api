using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterRequest request)
        {
            var user = await authService.RegisterAsync(request);
            if(user is null)
                return BadRequest("User already exists.");
            
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponse>> Login(LoginRequest request)
        {
            var tokens = await authService.LoginAsync(request);
            if (tokens is null)
                return BadRequest("Invalid email or password.");

            return Ok(tokens);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("assign-admin")]
        public async Task<ActionResult> AssignAdmin(AssignAdminRequest request)
        {
            return await authService.AssignAdminRoleAsync(request) ?
                Ok("User role succesfully updated to Admin.") :
                BadRequest("User not found or already an admin.");
        }

        [HttpPost("refresh-tokens")]
        public async Task<ActionResult<TokenResponse>> RefreshTokens(RefreshTokenRequest request)
        {
            var response = await authService.RefreshTokensAsync(request);
            if (response is null || response.AccessToken is null || response.RefreshToken is null)
                return Unauthorized("Invalid refresh token.");
            
            return Ok(response);
        }

        //Probni endpoint autentifikacije
        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnly()
        {
            return Ok("You are authenticated.");
        }

        //Probni endpoint prava pristupa preko uloge
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnly()
        {
            return Ok("You are admin.");
        }
    }
}
