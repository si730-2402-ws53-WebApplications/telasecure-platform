using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
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
public class EnvironmentDevicesController(
    IEnvironmentDeviceCommandService environmentDeviceCommandService,
    IEnvironmentDeviceQueryService environmentDeviceQueryService
    ) : ControllerBase
{
    [HttpGet("{enviroDeviceId:int}")]
    [SwaggerOperation("Get enviro device by id", "Get enviro device by its unique id", OperationId = "GetEnviroDeviceById")]
    [SwaggerResponse(200, "Enviro device found", typeof(EnvironmentDeviceResource))]
    [SwaggerResponse(404, "Enviro device not found")]
    public async Task<IActionResult> GetEnviroDeviceById(int enviroDeviceId)
    {
        var getEnviroDeviceByIdQuery = new GetEnvironmentDeviceByIdQuery(enviroDeviceId);
        var enviroDevice = await environmentDeviceQueryService.Handle(getEnviroDeviceByIdQuery);
        if (enviroDevice is null) return NotFound();
        var enviroDeviceResource = EnvironmentDeviceResourceFromEntityAssembler.ToResourceFromEntity(enviroDevice);
        return Ok(enviroDeviceResource);
    }
    
    
    [HttpPost]
    [SwaggerOperation("Create enviro device", "Create a new enviro device", OperationId = "CreateEnviroDevice")]
    [SwaggerResponse(201, "Enviro device created", typeof(EnvironmentDeviceResource))]
    [SwaggerResponse(400, "The device was not created")]
    public async Task<IActionResult> CreateEnviroDevice(CreateEnvironmentDeviceResource resource)
    {
        var createEnviroDeviceCommand = CreateEnvironmentDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var enviroDevice = await environmentDeviceCommandService.Handle(createEnviroDeviceCommand);
        if (enviroDevice is null) return BadRequest();
        var enviroDeviceResource = EnvironmentDeviceResourceFromEntityAssembler.ToResourceFromEntity(enviroDevice);
        return CreatedAtAction(nameof(GetEnviroDeviceById), new {enviroDeviceId = enviroDevice.Id}, enviroDeviceResource);
    }
    
    
    [HttpGet]
    [SwaggerOperation("Get all environment devices", "Get all environment devices", OperationId = "GetAllEnviroDevices")]
    [SwaggerResponse(200, "environment devices found", typeof(IEnumerable<EnvironmentDeviceResource>))]
    [SwaggerResponse(404, "environment devices not found")]
    public async Task<IActionResult> GetAllEnviroDevices()
    {
        var getAllEnviroDevicesQuery = new GetAllEnvironmentDevicesQuery();
        var enviroDevices = await environmentDeviceQueryService.Handle(getAllEnviroDevicesQuery);
        var enviroDeviceResources = enviroDevices.Select(EnvironmentDeviceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(enviroDeviceResources);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateEnvironmentDeviceResource resource)
    {
        var updateEnviroDeviceCommand = UpdateEnvironmentDeviceCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var updatedDevice = await environmentDeviceCommandService.Handle(updateEnviroDeviceCommand);
        if (updatedDevice == null)
        {
            return NotFound();
        }

        return Ok(updatedDevice);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteEnviroDeviceCommand = new DeleteEnvironmentDeviceCommand(id);
        var deleted = await environmentDeviceCommandService.Handle(deleteEnviroDeviceCommand);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}