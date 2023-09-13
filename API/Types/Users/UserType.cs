using Services.Dtos.Users;

namespace API.Types;

public class UserType : ObjectType<UserDto>
{
    protected override void Configure(IObjectTypeDescriptor<UserDto> descriptor)
    {
        descriptor.Field(u => u.Id).Type<UuidType>(); // this is a nullable
        descriptor.Field(u => u.Email).Type<NonNullType<StringType>>();
        descriptor.Field(u => u.Password).Type<NonNullType<StringType>>();
    }
}
