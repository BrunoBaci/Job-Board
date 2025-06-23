using System.IdentityModel.Tokens.Jwt;
using Job_Board_Back_End.Interfaces;
using Job_Board_Back_End.Models;
using Job_Board_Back_End.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IJwtHElper _jwtHelper; 
    public AuthController(IAuthService authService,  IJwtHElper jwtHelper) 
    {
        _authService = authService;
        _jwtHelper = jwtHelper;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        var user = _authService.Authenticate(req.Email, req.Password);
        if (user == null) return Unauthorized();
        var token = _jwtHelper.GenerateToken(user);
        return Ok(new { token, role = user.Role });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserRegisterRequest req)
    {
        var user = new User { Username = req.Username, Email = req.Email, Role = req.Role };
        if (!_authService.Register(user, req.Password)) return BadRequest("Email already in use");
        return Ok();
    }
}