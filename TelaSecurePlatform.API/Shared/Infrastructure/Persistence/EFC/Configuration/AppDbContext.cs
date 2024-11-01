using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Fabric>().HasKey(f => f.Id);
        builder.Entity<Fabric>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Fabric>().Property(f => f.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Fabric>().Property(f => f.StoreroomId).IsRequired();
        builder.Entity<Fabric>().Property(f => f.CategoryId).IsRequired();
        builder.Entity<Fabric>().Property(f => f.Quantity).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}
