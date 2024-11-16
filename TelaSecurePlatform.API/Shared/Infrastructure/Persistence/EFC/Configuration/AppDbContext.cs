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
        
        // Inventory bounded context
        
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
        
        //facilities bounded context
        
        builder.Entity<ClimateSensor>().HasKey(f => f.Id);
        builder.Entity<ClimateSensor>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ClimateSensor>().Property(f => f.Name).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.Model).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.Type).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.Image).IsRequired();
        builder.Entity<ClimateSensor>().Property(f => f.StoreRoomId).IsRequired();
        
        
        builder.Entity<EnvironmentDevice>().HasKey(e => e.Id);
        builder.Entity<EnvironmentDevice>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EnvironmentDevice>().Property(e => e.Name).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Model).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Type).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Unit).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Value).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.StoreRoomId).IsRequired();
        //builder.Entity<EnvironmentDevice>().Property(e => e.Status).IsRequired();
        
        
        builder.Entity<Storeroom>().HasKey(s => s.Id);
        builder.Entity<Storeroom>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Storeroom>().Property(s => s.Name).IsRequired();
        builder.Entity<Storeroom>().Property(s => s.Location).IsRequired();
        builder.Entity<Storeroom>().Property(s => s.Description).IsRequired();
        builder.Entity<Storeroom>().Property(s => s.Capacity).IsRequired();
        builder.Entity<Storeroom>().OwnsOne(s => s.Contact,
            c =>
            {
                c.WithOwner().HasForeignKey("Id");
                c.Property(p => p.Phone).HasColumnName("Phone");
                c.Property(p => p.Email).HasColumnName("Email");
            });
        
        builder.Entity<Storeroom>().OwnsOne(s => s.Temperature,
            t =>
            {
                t.WithOwner().HasForeignKey("Id");
                t.Property(p => p.Actual).HasColumnName("ActualTemperature");
                t.Property(p => p.Maximum).HasColumnName("MaximumTemperature");
                t.Property(p => p.Minimum).HasColumnName("MinimumTemperature");
                t.Property(p => p.Unit).HasColumnName("TemperatureUnit");
            });
        
        builder.Entity<Storeroom>().OwnsOne(s => s.Humidity,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(p => p.Actual).HasColumnName("ActualHumidity");
                h.Property(p => p.Maximum).HasColumnName("MaximumHumidity");
                h.Property(p => p.Minimum).HasColumnName("MinimumHumidity");
                h.Property(p => p.Unit).HasColumnName("HumidityUnit");
            });
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}
