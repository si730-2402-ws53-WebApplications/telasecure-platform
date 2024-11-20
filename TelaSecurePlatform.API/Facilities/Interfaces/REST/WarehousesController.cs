using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Warehouse Endpoints.")]
public class WarehousesController(
    IWarehouseCommandService warehouseCommandService,
    IWarehouseQueryService warehouseQueryService)
: ControllerBase
{
    [HttpGet("{warehouseId:int}")]
    [SwaggerOperation("Get Warehouse by Id", "Get a Warehouse by its unique identifier.", OperationId = "GetWarehouseById")]
    [SwaggerResponse(200, "The warehouse was found and returned.", typeof(WarehouseResource))]
    [SwaggerResponse(404, "The warehouse was not found.")]
    public async Task<IActionResult> GetWarehouseById(int warehouseId)
    {
        var getWarehouseByIdQuery = new GetWarehouseByIdQuery(warehouseId);
        var warehouse = await warehouseQueryService.Handle(getWarehouseByIdQuery);
        if (warehouse is null) return NotFound();
        var warehouseResource = WarehouseResourceFromEntityAssembler.ToResourceFromEntity(warehouse);
        return Ok(warehouseResource);
    }
    
    
    
    [HttpPost]
    [SwaggerOperation("Create warehouseId", "Create a new warehouse.", OperationId = "CreateWarehouse")]
    [SwaggerResponse(201, "The Warehouse was created.", typeof(WarehouseResource))]
    [SwaggerResponse(400, "The Warehouse was not created.")]
    public async Task<IActionResult> CreateWarehouse(CreateWarehouseResource resource)
    {
        var createWarehouseCommand = CreateWarehouseCommandFromResourceAssembler.ToCommandFromResource(resource);
        var warehouse = await warehouseCommandService.Handle(createWarehouseCommand);
        if (warehouse is null) return BadRequest();
        var warehouseResource = WarehouseResourceFromEntityAssembler.ToResourceFromEntity(warehouse);
        return CreatedAtAction(nameof(GetWarehouseById), new { warehouseId = warehouse.Id }, warehouseResource);
    }
    
    //actualizar un warehouse
    [HttpPut("{warehouseId:int}")]
    public async Task<IActionResult> UpdateWarehouse(int warehouseId, UpdateWarehouseResource resource)
    {
        var updateWarehouseCommand = UpdateWarehouseCommandFromResourceAssembler.ToCommand(warehouseId, resource);
        var warehouse = await warehouseCommandService.Handle(updateWarehouseCommand);
        if (warehouse is null) return BadRequest();
        var warehouseResource = WarehouseResourceFromEntityAssembler.ToResourceFromEntity(warehouse);
        return Ok(warehouseResource);
    }
    
    
    [HttpDelete("{warehouseId:int}")]
    public async Task<IActionResult> DeleteWarehouse(int warehouseId)
    {
        var deleteWarehouseCommand = new DeleteWarehouseCommand(warehouseId);
        var warehouseDeleted = await warehouseCommandService.Handle(deleteWarehouseCommand);
        if (!warehouseDeleted) return NotFound();
        return Ok();
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Warehouses", "Get all warehouses.", OperationId = "GetAllWarehouses")]
    [SwaggerResponse(200, "The warehouses were found and returned.", typeof(IEnumerable<WarehouseResource>))]
    [SwaggerResponse(404, "The warehouses were not found.")]
    public async Task<IActionResult> GetAllWarehouses()
    {
        var getAllWarehousesQuery = new GetAllWarehousesQuery();
        var warehouses = await warehouseQueryService.Handle(getAllWarehousesQuery);
        var warehouseResources = warehouses.Select(WarehouseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(warehouseResources);
    }
}