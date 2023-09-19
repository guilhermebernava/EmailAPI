using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmailHtmlTemplateController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromServices] IEmailHtmlTemplateCreateServices services, [FromBody] EmailHtmlTemplateDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        if(!result) return BadRequest();
        return Created("/EmailHtmlTemplate/", null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromServices] IEmailHtmlTemplateGetAllServices services)
    {
        var result = await services.ExecuteAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByNameAsync([FromServices] IEmailHtmlTemplateGetByNameServices services, [FromQuery] string name)
    {
        var result = await services.ExecuteAsync(name);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromServices] IEmailHtmlTemplateUpdateServices services, [FromBody] EmailHtmlTemplateUpdateDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        if (!result) return BadRequest();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromServices] IEmailHtmlTemplateDeleteServices services, [FromQuery] Guid id)
    {
        var result = await services.ExecuteAsync(id);
        if (!result) return BadRequest();
        return Ok();
    }
}
