using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Dtos;
using System.Net;
using System.Net.Mail;

namespace Services.Services;

public class SendEmailServices : ISendEmailServices
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SendEmailServices> _logger;
    private readonly SmtpClient _smtpClient;

    public SendEmailServices(IConfiguration configuration, ILogger<SendEmailServices> logger)
    {
        _configuration = configuration;
        _smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(_configuration["EmailSender:Email"], _configuration["EmailSender:Password"]),
            EnableSsl = true,
        };
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(EmailDto dto)
    {
        MailMessage mailMessage = new MailMessage
        {
            From = new MailAddress("notreply@noreply.com"),
            Subject = dto.Subject,
            Body = dto.Html,
           
            IsBodyHtml = true,
        };

        await Task.Run(() =>
        {
            foreach (var receiver in dto.EmailReceivers)
            {
                mailMessage.To.Add(receiver);
            }
        });


        try
        {
            await _smtpClient.SendMailAsync(mailMessage);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return false;
        }
    }
}
