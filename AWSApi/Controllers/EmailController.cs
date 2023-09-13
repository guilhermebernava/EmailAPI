using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace AWSApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost]
    [Route("SendEmail")]
    public async Task<IActionResult> SendEmail([FromServices] IEmailSenderServices services, [FromBody] EmailDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        return result == true ? Ok() : BadRequest();
    }
}
