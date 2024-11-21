/*using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using Newtonsoft.Json;

namespace TelaSecurePlatform.API.Report.Infrastructure;

public class YourDbContext : DbContext
{
    public DbSet<Summary> Summaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Summary>()
            .Property(s => s.ClimateSensorsData)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<ClimateSensorData>>(v)
            );
    }
}*/