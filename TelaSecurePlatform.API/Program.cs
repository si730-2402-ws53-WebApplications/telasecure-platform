using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;
using TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Infrastructure.Persistence.EFC.Repositories;
using TelaSecurePlatform.API.Inventory.Application.Internal.CommandServices;
using TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Inventory.Domain.Services;
using TelaSecurePlatform.API.Inventory.Infrastructure.Persistence.Repositories;
using TelaSecurePlatform.API.Shared.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Apply Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));



// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Connection string is null");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});


// OpenAPI/Swagger Configuration
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());


//dependency injection conf

//shared boudned context dependency inyection conf
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//inventory bounded context
builder.Services.AddScoped<IFabricRepository, FabricRepository>();
builder.Services.AddScoped<IFabricCommandService, FabricCommandService>();
builder.Services.AddScoped<IFabricQueryService, FabricQueryService>();

//facilities bounded context
builder.Services.AddScoped<IStoreroomRepository, StoreroomRepository>();
builder.Services.AddScoped<IStoreroomCommandService, StoreroomCommandService>();
builder.Services.AddScoped<IStoreroomQueryService, StoreroomQueryService>();

builder.Services.AddScoped<IClimateSensorRepository, ClimateSensorRepository>();
builder.Services.AddScoped<IClimateSensorCommandService, ClimateSensorCommandService>();
builder.Services.AddScoped<IClimateSensorQueryService, ClimateSensorQueryService>();

builder.Services.AddScoped<IEnviroDeviceRepository, EnviroDeviceRepository>();
builder.Services.AddScoped<IEnviroDeviceCommandService, EnviroDeviceCommandService>();
builder.Services.AddScoped<IEnviroDeviceQueryService, EnviroDeviceQueryService>();


var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    
    
// Eliminar la base de datos si existe
    context.Database.EnsureDeleted();

// Crear la base de datos
    context.Database.EnsureCreated();
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();