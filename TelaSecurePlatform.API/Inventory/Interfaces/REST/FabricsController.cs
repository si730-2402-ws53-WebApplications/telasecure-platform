using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Domain.Model.Queries;
using TelaSecurePlatform.API.Inventory.Domain.Services;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Fabrics Endpoints.")]
public class FabricsController(
    IFabricCommandService fabricCommandService,
    IFabricQueryService fabricQueryService
    ) : ControllerBase
{
    
    
    [HttpGet("{fabricId:int}")]
    [SwaggerOperation(
        Summary = "Get fabric by id",
        Description = "Get fabric by id",
        OperationId = "GetFabricById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The fabric with the given id", typeof(FabricResource))]
    public async Task<IActionResult> GetFabricById([FromRoute] int fabricId)
    {
        var fabric = await fabricQueryService.Handle(new GetFabricByIdQuery(fabricId));
        if (fabric is null) return NotFound();
        var fabricResource = FabricResourceFromEntityAssembler.ToResourceFromEntity(fabric);
        return Ok(fabricResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new fabric",
        Description = "Create a new fabric",
        OperationId = "CreateFabric"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The fabric created", typeof(FabricResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The fabric could not be created")]
    public async Task<IActionResult> CreateFabric([FromBody] CreateFabricResource resource)
    {
        var createFabricCommand = CreateFabricCommandFromResourceAssembler.ToCommandFromResource(resource);
        var fabric = await fabricCommandService.Handle(createFabricCommand);
        if (fabric is null) return BadRequest();
        var fabricResource = FabricResourceFromEntityAssembler.ToResourceFromEntity(fabric);
        return CreatedAtAction(nameof(GetFabricById), new {fabricId = fabric.Id}, fabricResource);
    }
    
    
    [HttpPut("{fabricId:int}")]
    public async Task<IActionResult> UpdateFabric([FromRoute] int fabricId, UpdateFabricResource resource)
    {
        var updateFabricCommand = UpdateFabricCommandFromResourceAssembler.ToCommand(fabricId, resource);
        var fabric = await fabricCommandService.Handle(updateFabricCommand);
        if (fabric is null) return NotFound();
        var fabricResource = FabricResourceFromEntityAssembler.ToResourceFromEntity(fabric);
        return Ok(fabricResource);
    }
    
    
    [HttpDelete("{fabricId:int}")]
    public async Task<IActionResult> DeleteFabric([FromRoute] int fabricId)
    {
        var deleteFabricCommand = new DeleteFabricCommand(fabricId);
        var isDeleted = await fabricCommandService.Handle(deleteFabricCommand);
        if (!isDeleted) return NotFound();
        return NoContent();
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all fabrics",
        Description = "Get all fabrics",
        OperationId = "GetAllFabrics"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "All fabrics", typeof(IEnumerable<FabricResource>))]
    public async Task<IActionResult> GetAllFabrics()
    {
        var getAllFabricsQuery = new GetAllFabricsQuery();
        var fabrics = await fabricQueryService.Handle(getAllFabricsQuery);
        var fabricResources = fabrics.Select(FabricResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(fabricResources);
    }
}