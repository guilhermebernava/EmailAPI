using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromServices] IUserCreateServices services, [FromServices] ILogger<UserController> logger, [FromBody] UserDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        return result ? Created("/User/Login", null) : BadRequest();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUserAsync([FromServices] IUserUpdateServices services, [FromBody] UserDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteUserAsync([FromServices] IUserDeleteServices services, [FromQuery] Guid id)
    {
        var result = await services.ExecuteAsync(id);
        return result ? Ok() : BadRequest();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromServices] IUserLoginServices services, [FromBody] LoginDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        return Ok(result);
    }
}