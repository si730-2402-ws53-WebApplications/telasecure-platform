using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TelaSecurePlatform.API.Facilities.Application.ACL;
using TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;
using TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Infrastructure.Persistence.EFC.Repositories;
using TelaSecurePlatform.API.Facilities.Interfaces.ACL;
using TelaSecurePlatform.API.IAM.Application.ACL.Services;
using TelaSecurePlatform.API.IAM.Application.Internal.CommandServices;
using TelaSecurePlatform.API.IAM.Application.Internal.OutboundServices;
using TelaSecurePlatform.API.IAM.Application.Internal.QueryServices;
using TelaSecurePlatform.API.IAM.Domain.Repositories;
using TelaSecurePlatform.API.IAM.Domain.Services;
using TelaSecurePlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using TelaSecurePlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using TelaSecurePlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using TelaSecurePlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using TelaSecurePlatform.API.IAM.Interfaces.ACL;
using TelaSecurePlatform.API.Inventory.Application.Internal.CommandServices;
using TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices;
using TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices.acl;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Inventory.Domain.Services;
using TelaSecurePlatform.API.Inventory.Infrastructure.Persistence.Repositories;
using TelaSecurePlatform.API.Profiles.Application.Internal.CommandServices;
using TelaSecurePlatform.API.Profiles.Application.Internal.QueryServices;
using TelaSecurePlatform.API.Profiles.Domain.Repositories;
using TelaSecurePlatform.API.Profiles.Domain.Services;
using TelaSecurePlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
/*using TelaSecurePlatform.API.Report.Application.Internal.CommandServices;
using TelaSecurePlatform.API.Report.Application.Internal.QueryServices;
using TelaSecurePlatform.API.Report.Domain.Repositories;
using TelaSecurePlatform.API.Report.Domain.Services;
using TelaSecurePlatform.API.Report.Infrastructure.Persistence.Repositories;*/
using TelaSecurePlatform.API.Shared.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Apply Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add CORS Policy (to all controllers)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => 
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader());
});

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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TelaSecure Platform API",
            Version = "v1",
            Description = "Waveguard - TelaSecure Platform",
            TermsOfService = new Uri("https://waveguard.telasecure.com"),
            Contact = new OpenApiContact
            {
                Name   = "Waveguard Contact",
                Email = "contact@waveguard.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url  = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    options.EnableAnnotations();
});

// Dependency injection configuration

// Shared bounded context dependency injection configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Inventory bounded context
builder.Services.AddScoped<IFabricRepository, FabricRepository>();
builder.Services.AddScoped<IFabricCommandService, FabricCommandService>();
builder.Services.AddScoped<IFabricQueryService, FabricQueryService>();
builder.Services.AddScoped<IExternalWarehouseService, ExternalWarehouseService>();

// Facilities bounded context
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IWarehouseCommandService, WarehouseCommandService>();
builder.Services.AddScoped<IWarehouseQueryService, WarehouseQueryService>();
builder.Services.AddScoped<IWarehousesContextFacade, WarehousesContextFacade>();

builder.Services.AddScoped<IClimateSensorRepository, ClimateSensorRepository>();
builder.Services.AddScoped<IClimateSensorCommandService, ClimateSensorCommandService>();
builder.Services.AddScoped<IClimateSensorQueryService, ClimateSensorQueryService>();

builder.Services.AddScoped<IEnvironmentDeviceRepository, EnvironmentDeviceRepository>();
builder.Services.AddScoped<IEnvironmentDeviceCommandService, EnvironmentDeviceCommandService>();
builder.Services.AddScoped<IEnvironmentDeviceQueryService, EnvironmentDeviceQueryService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();


// Profiles Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

// TokenSettings configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();

// Verify database objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    //context.Database.EnsureCreated();
    
    // Eliminar la base de datos si existe
    context.Database.EnsureDeleted();

    // Crear la base de datos
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();