using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost]
    public IActionResult SendEmailAsync([FromServices] ISendEmailServices services, [FromServices] IBackgroundJobClient backgroundJobClient, [FromBody] EmailDto dto)
    {
        backgroundJobClient.Schedule<ISendEmailServices>(_ => services.ExecuteAsync(dto),TimeSpan.FromSeconds(10));
        return Ok();
    }

    [HttpPost]
    [Route("AutomaticEmail")]
    public IActionResult SendAutomaticEmailAsync([FromServices] ISendEmailServices services,[FromBody] AutomaticEmailDto dto)
    {
        //TODO add a way to pass a CRON to this automatic job
        RecurringJob.AddOrUpdate(dto.Name, () => services.ExecuteAsync(dto.EmailDto), "5 15-23 * * *");
        return Ok();
    }

    [HttpDelete]
    [Route("AutomaticEmail")]
    public IActionResult SendAutomaticEmailAsync([FromBody] string name)
    {
        RecurringJob.RemoveIfExists(name);
        return Ok();
    }
}
