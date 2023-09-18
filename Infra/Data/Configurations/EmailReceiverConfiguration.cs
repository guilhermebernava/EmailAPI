using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations;

public class EmailReceiverConfiguration : EntityConfiguration<EmailReceiver>
{
    public override void Configure(EntityTypeBuilder<EmailReceiver> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Recurring)
            .IsRequired();

        builder.Property(u => u.ClientType)
            .IsRequired();

        builder.Property(u => u.Name)
           .IsRequired();
    }
}
