using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
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
        
        /*
        builder.Entity<Fabric>().Property(f => f.Status).IsRequired();
        
        builder.Entity<Fabric>().OwnsOne(f => f.Staff,
            s =>
            {
                s.WithOwner().HasForeignKey("Id");
                s.Property(v => v.Value).HasColumnName("StaffId");
            });
        */
        
        builder.Entity<ClimateSensor>().HasKey(f => f.Id);
        builder.Entity<ClimateSensor>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ClimateSensor>().Property(f => f.Name).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.Model).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.Type).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.Image).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.StoreRoomId).IsRequired();
        
        /*
        builder.Entity<EnviroDevice>().HasKey(e => e.Id);
        builder.Entity<EnviroDevice>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EnviroDevice>().Property(e => e.Name).IsRequired();
        builder.Entity<EnviroDevice>().Property(e => e.Model).IsRequired();
        builder.Entity<EnviroDevice>().Property(e => e.Type).IsRequired();
        builder.Entity<EnviroDevice>().Property(e => e.Unit).IsRequired();
        builder.Entity<EnviroDevice>().Property(e => e.Value).IsRequired();
        builder.Entity<EnviroDevice>().Property(e => e.StoreRoomId).IsRequired();
        builder.Entity<EnviroDevice>().Property(e => e.Status).IsRequired();
        */
        
        builder.UseSnakeCaseNamingConvention();
    }
}
