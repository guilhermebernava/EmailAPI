using Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Dtos;
using System.Net;
using System.Net.Mail;

namespace Services.Services;

public class SendEmailServices : ISendEmailServices
{
    private readonly IValidator<EmailDto> _validator;
    private readonly IEmailReceiverRepository _emailReceiverRepository;
    private readonly IEmailHtmlTemplateRepository _emailHtmlTemplateRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<SendEmailServices> _logger;
    private readonly SmtpClient _smtpClient;

    public SendEmailServices(IConfiguration configuration, ILogger<SendEmailServices> logger, IValidator<EmailDto> validator, IEmailReceiverRepository emailReceiverRepository, IEmailHtmlTemplateRepository emailHtmlTemplateRepository)
    {
        _configuration = configuration;
        _smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(_configuration["EmailSender:Email"], _configuration["EmailSender:Password"]),
            EnableSsl = true,
        };
        _logger = logger;
        _validator = validator;
        _emailReceiverRepository = emailReceiverRepository;
        _emailHtmlTemplateRepository = emailHtmlTemplateRepository;
    }

    public async Task<bool> ExecuteAsync(EmailDto dto)
    {
        var validated = _validator.Validate(dto);
        if (!validated.IsValid) throw new ValidationException(validated.Errors);

        MailMessage mailMessage = await _generateMailMessage(dto);
        await _addEmailReceivers(dto, mailMessage);

        return await _sendEmail(mailMessage);
    }

    private async Task<bool> _sendEmail(MailMessage mailMessage)
    {
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

    private async Task _addEmailReceivers(EmailDto dto, MailMessage mailMessage)
    {
        if (dto.EmailReceiverFromDb)
        {
            await Task.Run(async () =>
            {
                var receivers = await _emailReceiverRepository.GetAllAsync();
                foreach (var receiver in receivers)
                {
                    mailMessage.To.Add(receiver.Email);
                }
            });
            return;
        }

        if (dto.EmailReceivers == null) throw new Exception("EmailReceivers is NULL");
        await Task.Run(() =>
        {
            foreach (var receiver in dto.EmailReceivers)
            {
                mailMessage.To.Add(receiver);
            }
        });

    }

    private async Task<MailMessage> _generateMailMessage(EmailDto dto)
    {
        if (dto.FromTemplate)
        {
            if (dto.TemplateName == null) throw new Exception("TemplateName can not be null when FROM_TEMPLATE is TRUE");

            var template = await _emailHtmlTemplateRepository.GetByName(dto.TemplateName);
            return new MailMessage
            {
                From = new MailAddress("notreply@noreply.com"),
                Subject = template.Subject,
                Body = template.HtmlContent,
                IsBodyHtml = true,
            };
        }

        return new MailMessage
        {
            From = new MailAddress("noreply@noreply.com"),
            Subject = dto.Subject,
            Body = dto.Html,
            IsBodyHtml = true,
        };
    }



}
