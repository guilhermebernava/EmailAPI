using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations;

public class EmailHtmlTemplateConfiguration : EntityConfiguration<EmailHtmlTemplate>
{
    public override void Configure(EntityTypeBuilder<EmailHtmlTemplate> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.HtmlContent)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.EmailType)
            .IsRequired();

        builder.Property(u => u.Subject)
            .IsRequired();

        builder.Property(u => u.EmailType)
           .IsRequired();

        builder.Property(u => u.Name)
          .IsRequired();
    }
}
