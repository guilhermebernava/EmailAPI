using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations;

public class UserConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.HashedPassword)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Salt)
            .IsRequired()
            .HasMaxLength(255);
    }
}
