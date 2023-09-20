using AutoMapper;
using Domain.Entities;
using Services.Dtos;

namespace Services.Mappers;


public class EmailReceiverMappers : Profile
{
    public EmailReceiverMappers()
    {
        CreateMap<EmailReceiverDto, EmailReceiver>();
        CreateMap<EmailReceiver, EmailReceiverDto>();
        CreateMap<EmailReceiverUpdateDto, EmailReceiver>();
        CreateMap<EmailReceiver, EmailReceiverUpdateDto>();
    }
}
