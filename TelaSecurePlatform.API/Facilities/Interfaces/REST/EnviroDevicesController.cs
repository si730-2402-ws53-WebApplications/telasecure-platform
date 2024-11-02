using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST;

[ApiController]
[Route("api/v1/enviro-devices")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available enviro devices endpoints")]
public class EnviroDevicesController(
    IEnviroDeviceCommandService enviroDeviceCommandService,
    IEnviroDeviceQueryService enviroDeviceQueryService
    ) : ControllerBase
{
    [HttpGet("{enviroDeviceId:int}")]
    [SwaggerOperation("Get enviro device by id", "Get enviro device by its unique id", OperationId = "GetEnviroDeviceById")]
    [SwaggerResponse(200, "Enviro device found", typeof(EnviroDeviceResource))]
    [SwaggerResponse(404, "Enviro device not found")]
    public async Task<IActionResult> GetEnviroDeviceById(int enviroDeviceId)
    {
        var getEnviroDeviceByIdQuery = new GetEnviroDeviceByIdQuery(enviroDeviceId);
        var enviroDevice = await enviroDeviceQueryService.Handle(getEnviroDeviceByIdQuery);
        if (enviroDevice is null) return NotFound();
        var enviroDeviceResource = EnviroDeviceResourceFromEntityAssembler.ToResourceFromEntity(enviroDevice);
        return Ok(enviroDeviceResource);
    }
    
    
    [HttpPost]
    [SwaggerOperation("Create enviro device", "Create a new enviro device", OperationId = "CreateEnviroDevice")]
    [SwaggerResponse(201, "Enviro device created", typeof(EnviroDeviceResource))]
    [SwaggerResponse(400, "The device was not created")]
    public async Task<IActionResult> CreateEnviroDevice(CreateEnviroDeviceResource resource)
    {
        var createEnviroDeviceCommand = CreateEnviroDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var enviroDevice = await enviroDeviceCommandService.Handle(createEnviroDeviceCommand);
        if (enviroDevice is null) return BadRequest();
        var enviroDeviceResource = EnviroDeviceResourceFromEntityAssembler.ToResourceFromEntity(enviroDevice);
        return CreatedAtAction(nameof(GetEnviroDeviceById), new {enviroDeviceId = enviroDevice.Id}, enviroDeviceResource);
    }
    
    
    [HttpGet]
    [SwaggerOperation("Get all enviro devices", "Get all enviro devices", OperationId = "GetAllEnviroDevices")]
    [SwaggerResponse(200, "Enviro devices found", typeof(IEnumerable<EnviroDeviceResource>))]
    [SwaggerResponse(404, "Enviro devices not found")]
    public async Task<IActionResult> GetAllEnviroDevices()
    {
        var getAllEnviroDevicesQuery = new GetAllEnviroDevicesQuery();
        var enviroDevices = await enviroDeviceQueryService.Handle(getAllEnviroDevicesQuery);
        var enviroDeviceResources = enviroDevices.Select(EnviroDeviceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(enviroDeviceResources);
    }
}