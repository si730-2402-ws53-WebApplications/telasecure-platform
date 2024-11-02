using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Storeroom Endpoints.")]
public class StoreroomsController(
    IStoreroomCommandService storeroomCommandService,
    IStoreroomQueryService storeroomQueryService)
: ControllerBase
{
    [HttpGet("{storeroomId:int}")]
    [SwaggerOperation("Get Storeroom by Id", "Get a storeroom by its unique identifier.", OperationId = "GetStoreroomById")]
    [SwaggerResponse(200, "The storeroom was found and returned.", typeof(StoreroomResource))]
    [SwaggerResponse(404, "The storeroom was not found.")]
    public async Task<IActionResult> GetStoreroomById(int storeroomId)
    {
        var getStoreroomByIdQuery = new GetStoreroomByIdQuery(storeroomId);
        var storeroom = await storeroomQueryService.Handle(getStoreroomByIdQuery);
        if (storeroom is null) return NotFound();
        var storeroomResource = StoreroomResourceFromEntityAssembler.ToResourceFromEntity(storeroom);
        return Ok(storeroomResource);
    }
    
    
    
    [HttpPost]
    [SwaggerOperation("Create Storeroom", "Create a new storeroom.", OperationId = "CreateStoreroom")]
    [SwaggerResponse(201, "The storeroom was created.", typeof(StoreroomResource))]
    [SwaggerResponse(400, "The storeroom was not created.")]
    public async Task<IActionResult> CreateStoreroom(CreateStoreroomResource resource)
    {
        var createStoreroomCommand = CreateStoreroomCommandFromResourceAssembler.ToCommandFromResource(resource);
        var storeroom = await storeroomCommandService.Handle(createStoreroomCommand);
        if (storeroom is null) return BadRequest();
        var storeroomResource = StoreroomResourceFromEntityAssembler.ToResourceFromEntity(storeroom);
        return CreatedAtAction(nameof(GetStoreroomById), new { storeroomId = storeroom.Id }, storeroomResource);
    }
    
    
    [HttpGet]
    [SwaggerOperation("Get All Storerooms", "Get all storerooms.", OperationId = "GetAllStorerooms")]
    [SwaggerResponse(200, "The storerooms were found and returned.", typeof(IEnumerable<StoreroomResource>))]
    [SwaggerResponse(404, "The storerooms were not found.")]
    public async Task<IActionResult> GetAllStorerooms()
    {
        var getAllStoreroomsQuery = new GetAllStoreroomsQuery();
        var storerooms = await storeroomQueryService.Handle(getAllStoreroomsQuery);
        var storeroomResources = storerooms.Select(StoreroomResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(storeroomResources);
    }
}