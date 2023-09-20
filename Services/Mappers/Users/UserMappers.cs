using AutoMapper;
using Domain.Entities;
using Services.Dtos;

namespace Services.Mappers.Users;

public class UserMappers : Profile
{
    public UserMappers()
    {
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();

        CreateMap<UserUpdateDto, User>();
        CreateMap<User, UserUpdateDto>();

        CreateMap<LoginDto, User>();
        CreateMap<User, LoginDto>();
    }
}
