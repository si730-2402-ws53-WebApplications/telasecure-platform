using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.IAM.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Profiles.Domain.Model.Aggregates;
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
        builder.Entity<Fabric>().Property(f => f.WarehouseId).IsRequired();
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
        builder.Entity<ClimateSensor>().Property(f => f.WarehouseId).IsRequired();
        
        builder.Entity<Report.Domain.Model.Aggregates.Summary>().HasKey(s => s.Id);
        builder.Entity<Report.Domain.Model.Aggregates.Summary>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report.Domain.Model.Aggregates.Summary>().Property(s => s.Date).IsRequired();
        builder.Entity<Report.Domain.Model.Aggregates.Summary>().Property(s => s.FabricsData).IsRequired();
        builder.Entity<Report.Domain.Model.Aggregates.Summary>().Property(s => s.EnviroDevicesData).IsRequired();
        builder.Entity<Report.Domain.Model.Aggregates.Summary>().Property(s => s.ClimateSensorsData).IsRequired();
        
        builder.Entity<EnvironmentDevice>().HasKey(e => e.Id);
        builder.Entity<EnvironmentDevice>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EnvironmentDevice>().Property(e => e.Name).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Model).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Type).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Unit).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.Value).IsRequired();
        builder.Entity<EnvironmentDevice>().Property(e => e.WarehouseId).IsRequired();
        //builder.Entity<EnvironmentDevice>().Property(e => e.Status).IsRequired();
        
        
        builder.Entity<Warehouse>().HasKey(s => s.Id);
        builder.Entity<Warehouse>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Warehouse>().Property(s => s.Name).IsRequired();
        builder.Entity<Warehouse>().Property(s => s.Location).IsRequired();
        builder.Entity<Warehouse>().Property(s => s.Description).IsRequired();
        builder.Entity<Warehouse>().Property(s => s.Capacity).IsRequired();
        builder.Entity<Warehouse>().OwnsOne(s => s.Contact,
            c =>
            {
                c.WithOwner().HasForeignKey("Id");
                c.Property(p => p.Phone).HasColumnName("Phone");
                c.Property(p => p.Email).HasColumnName("Email");
            });
        
        builder.Entity<Warehouse>().OwnsOne(s => s.Temperature,
            t =>
            {
                t.WithOwner().HasForeignKey("Id");
                t.Property(p => p.Actual).HasColumnName("ActualTemperature");
                t.Property(p => p.Maximum).HasColumnName("MaximumTemperature");
                t.Property(p => p.Minimum).HasColumnName("MinimumTemperature");
                t.Property(p => p.Unit).HasColumnName("TemperatureUnit");
            });
        
        builder.Entity<Warehouse>().OwnsOne(s => s.Humidity,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(p => p.Actual).HasColumnName("ActualHumidity");
                h.Property(p => p.Maximum).HasColumnName("MaximumHumidity");
                h.Property(p => p.Minimum).HasColumnName("MinimumHumidity");
                h.Property(p => p.Unit).HasColumnName("HumidityUnit");
            });
        
        // Profiles Context
        
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet");
                a.Property(s => s.Number).HasColumnName("AddressNumber");
                a.Property(s => s.City).HasColumnName("AddressCity");
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                a.Property(s => s.Country).HasColumnName("AddressCountry");
            });
        
        // IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}
