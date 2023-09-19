using FluentValidation;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class EmailController : ControllerBase
{
    [HttpPost]
    public IActionResult SendEmailAsync([FromServices] ISendEmailServices services, [FromServices] IBackgroundJobClient backgroundJobClient, [FromBody] EmailDto dto)
    {
        backgroundJobClient.Schedule<ISendEmailServices>(_ => services.ExecuteAsync(dto), TimeSpan.FromSeconds(10));
        return Ok();
    }

    [HttpPost]
    [Route("AutomaticEmail")]
    public IActionResult SendAutomaticEmailAsync([FromServices] ISendEmailServices services, [FromServices] IValidator<AutomaticEmailDto> validator, [FromBody] AutomaticEmailDto dto)
    {
        var validated = validator.Validate(dto);
        if (!validated.IsValid) throw new ValidationException(validated.Errors);

        try
        {
            RecurringJob.AddOrUpdate(dto.Name, () => services.ExecuteAsync(dto.EmailDto), dto.Cron);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    #region JOBS
    [HttpGet]
    [Route("GetJobs")]
    public async Task<IActionResult> GetJobsAsync([FromServices] IGetJobsServices services)
    {
        return Ok(await services.ExecuteAsync());
    }

    [HttpDelete]
    [Route("RemoveRecuringJobs")]
    public IActionResult SendAutomaticEmailAsync([FromBody] string jobName)
    {
        try
        {
            RecurringJob.RemoveIfExists(jobName);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}
