using Core.Security.Dtos;
using Core.Security.Entities;
using Devs.Application.Features.Auths.Commands.Register;
using Devs.Application.Features.Auths.Dtos;
using Devs.Application.Features.Users.Commands.LoginUser;
using Devs.Application.Features.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        RegisterCommand registerCommand = new()
        {
            IpAddress = GetIpAddress(),
            UserForRegisterDto = userForRegisterDto
        };

        RegisteredDto result = await Mediator!.Send(registerCommand);
        setRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }


    private void setRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var result = await Mediator!.Send(loginUserCommand);
        return Ok(result);
    }
}