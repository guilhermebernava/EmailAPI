using Services.Dtos.Users;

namespace API.Types;

public class LoginType : ObjectType<LoginDto>
{
    protected override void Configure(IObjectTypeDescriptor<LoginDto> descriptor)
    {
        descriptor.Field(u => u.Email).Type<NonNullType<StringType>>();
        descriptor.Field(u => u.Password).Type<NonNullType<StringType>>();
    }
}