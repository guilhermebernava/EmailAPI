using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.Extensions.Configuration;
using Services.Dtos;
using System.Net;

namespace Services.Services;

public class EmailSenderServices : IEmailSenderServices
{
    private readonly IAmazonSimpleEmailService _ses;
    private readonly IConfiguration _configuration;

    public EmailSenderServices(IAmazonSimpleEmailService ses, IConfiguration configuration)
    {
        _ses = ses;
        _configuration = configuration;
    }

    public async Task<bool> ExecuteAsync(EmailDto dto)
    {
        var sendRequest = new SendEmailRequest
        {
            Source = _configuration["EmailSender"],
            Destination = new Destination
            {
                ToAddresses = new List<string> { dto.EmailTo }
            },
            Message = new Message
            {
                Subject = new Content(dto.Subject),
                Body = new Body
                {
                    Html = new Content
                    {
                        Charset = "UTF-8",
                        Data = dto.Html
                    }
                }
            }
        };

        var result = await _ses.SendEmailAsync(sendRequest);
        return result.HttpStatusCode == HttpStatusCode.OK;
    }
}
