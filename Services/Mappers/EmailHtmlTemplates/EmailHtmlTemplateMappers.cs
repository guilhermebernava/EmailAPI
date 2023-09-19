using AutoMapper;
using Domain.Entities;
using Services.Dtos;

namespace Services.Mappers;

public class EmailHtmlTemplateMappers : Profile
{
    public EmailHtmlTemplateMappers()
    {
        CreateMap<EmailHtmlTemplateDto, EmailHtmlTemplate>();
        CreateMap<EmailHtmlTemplate, EmailHtmlTemplateDto>();
        CreateMap<EmailHtmlTemplateUpdateDto, EmailHtmlTemplate>();
        CreateMap<EmailHtmlTemplate, EmailHtmlTemplateUpdateDto>();
    }
}