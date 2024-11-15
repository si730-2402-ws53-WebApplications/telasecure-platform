using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/climate-sensors")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available operations for climate sensors")]
public class ClimateSensorsController(IClimateSensorCommandService climateSensorCommandService,
    IClimateSensorQueryService climateSensorQueryService) : ControllerBase
{
    [HttpGet("{climateSensorId:int}")]
    [SwaggerOperation("Get climate sensor by id", "Get a climate sensor by its unique identifier",
        OperationId = "GetClimateSensorById")]
    [SwaggerResponse(200, "Climate sensor found", typeof(ClimateSensorResource))]
    [SwaggerResponse(404, "Climate sensor not found")]
    public async Task<IActionResult> GetClimateSensorById(int climateSensorId)
    {
        var getClimateSensorByIdQuery = new GetClimateSensorByIdQuery(climateSensorId);
        var climateSensor = await climateSensorQueryService.Handle(getClimateSensorByIdQuery);
        if (climateSensor is null) return NotFound();
        var climateSensorResource = ClimateSensorResourceFromEntityAssembler.ToResourceFromEntity(climateSensor);
        return Ok(climateSensorResource);
    }


    [HttpPost]
    [SwaggerOperation("Create climate sensor", "Create a new climate sensor", OperationId = "CreateClimateSensor")]
    [SwaggerResponse(201, "Climate sensor created", typeof(ClimateSensorResource))]
    [SwaggerResponse(400, "The sensor was not created")]
    public async Task<IActionResult> CreateClimateSensor(CreateClimateSensorResource resource)
    {
        var createClimateSensorCommand = CreateClimateSensorCommandFromResourceAssembler.ToCommandFromResource(resource);
        var climateSensor = await climateSensorCommandService.Handle(createClimateSensorCommand);
        if (climateSensor is null) return BadRequest();
        var climateSensorResource = ClimateSensorResourceFromEntityAssembler.ToResourceFromEntity(climateSensor);
        return CreatedAtAction(nameof(GetClimateSensorById), new {climateSensorId = climateSensor.Id}, climateSensorResource);
    }
    
       
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateClimateSensorResource resource)
    {
        var updateClimateSensorCommand = UpdateClimateSensorCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var updatedSensor = await climateSensorCommandService.Handle(updateClimateSensorCommand);
        if (updatedSensor == null)
        {
            return NotFound();
        }

        return Ok(updatedSensor);
    }
    
    
    [HttpGet]
    [SwaggerOperation("Get all climate sensors", "Get all climate sensors", OperationId = "GetAllClimateSensors")]
    [SwaggerResponse(200, "Climate sensors found", typeof(IEnumerable<ClimateSensorResource>))]
    [SwaggerResponse(404, "Climate sensors not found")]
    public async Task<IActionResult> GetAllClimateSensors()
    {
        var getAllClimateSensorsQuery = new GetAllClimateSensorsQuery();
        var climateSensors = await climateSensorQueryService.Handle(getAllClimateSensorsQuery);
        var climateSensorResources = climateSensors.Select(ClimateSensorResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(climateSensorResources);
    }
    
 
    
    [HttpDelete]
    [SwaggerOperation("Delete climate sensor", "Delete a climate sensor", OperationId = "DeleteClimateSensor")]
    [SwaggerResponse(200, "Climate sensor deleted")]
    [SwaggerResponse(404, "Climate sensor not found")]
    public async Task<IActionResult> DeleteClimateSensor(int climateSensorId)
    {
        var deleteClimateSensorCommand = new DeleteClimateSensorCommand(climateSensorId);
        var climateSensorDeleted = await climateSensorCommandService.Handle(deleteClimateSensorCommand);
        if (!climateSensorDeleted) return NotFound();
        return Ok();
    }
}