using Domain.Entities;
using Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<EmailReceiver> EmailReceivers { get; set; }
    public DbSet<EmailHtmlTemplate> EmailHtmlTemplates { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EmailReceiverConfiguration());
        modelBuilder.ApplyConfiguration(new EmailHtmlTemplateConfiguration());
    }
}
