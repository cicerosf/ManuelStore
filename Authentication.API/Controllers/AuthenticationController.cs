using Authentication.API.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(string userName)
    {
        if (!userName.IsNullOrEmpty())
        {
            var token = _authenticationService.GenerateToken(userName);

            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}
