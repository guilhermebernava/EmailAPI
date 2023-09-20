using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmailReceiverController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromServices] IEmailReceiverCreateServices services, [FromBody] EmailReceiverDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        if (!result) return BadRequest();
        return Created("/EmailReceiver/", null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromServices] IEmailReceiverGetAllServices services)
    {
        var result = await services.ExecuteAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByNameAsync([FromServices] IEmailReceiverGetByNameServices services, [FromQuery] string name)
    {
        var result = await services.ExecuteAsync(name);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromServices] IEmailReceiverUpdateServices services, [FromBody] EmailReceiverUpdateDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        if (!result) return BadRequest();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromServices] IEmailReceiverDeleteServices services, [FromQuery] Guid id)
    {
        var result = await services.ExecuteAsync(id);
        if (!result) return BadRequest();
        return Ok();
    }
}
