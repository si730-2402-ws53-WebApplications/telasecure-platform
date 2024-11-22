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
[Route("api/v1/categories")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Categories endpoints")]
public class CategoriesController(
    ICategoryCommandService categoryCommandService,
    ICategoryQueryService categoryQueryService) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a category by id",
        Description = "Get a category by id",
        OperationId = "GetCategoryById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The category was found", typeof(CategoryResource))]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var category = await categoryQueryService.Handle(new GetCategoryByIdQuery(id));
        if (category == null)
        {
            return NotFound();
        }

        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetAllCategories"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The categories were found", typeof(IEnumerable<CategoryResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await categoryQueryService.Handle(new GetAllCategoriesQuery());
        var categoryResources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a category",
        Description = "Create a category",
        OperationId = "CreateCategory"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The category was created", typeof(CategoryResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var category = await categoryCommandService.Handle(new CreateCategoryCommand(resource.Name));
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, categoryResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a category",
        Description = "Update a category",
        OperationId = "UpdateCategory"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The category was updated", typeof(CategoryResource))]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryResource resource)
    {
        var category = await categoryCommandService.Handle(new UpdateCategoryCommand(id, resource.Name));
        if (category == null)
        {
            return NotFound();
        }

        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }

    //suggestions

    [HttpGet("{categoryId}/suggestions")]
    [SwaggerOperation(
        Summary = "Get all suggestions by category id",
        Description = "Get all suggestions by category id",
        OperationId = "GetAllSuggestionsByCategoryId"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The suggestions were found", typeof(IEnumerable<SuggestionResource>))]
    public async Task<IActionResult> GetAllSuggestionsByCategoryId([FromRoute] int categoryId)
    {
        var suggestions = await categoryQueryService.Handle(new GetAllSuggestionsByCategoryId(categoryId));
        var suggestionResources = suggestions.Select(SuggestionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(suggestionResources);
    }

    [HttpPost("{categoryId}/suggestions")]
    [SwaggerOperation(
        Summary = "Create a suggestion",
        Description = "Create a suggestion",
        OperationId = "CreateSuggestion"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The suggestion was created", typeof(SuggestionResource))]
    public async Task<IActionResult> CreateSuggestion([FromRoute] int categoryId,
        [FromBody] CreateSuggestionResource resource)
    {
        var category = await categoryQueryService.Handle(new GetCategoryByIdQuery(categoryId));
        if (category == null)  return NotFound();
        
        var suggestion =
            await categoryCommandService.Handle(new CreateSuggestionCommand(category.Id, resource.Description, category));
        if (suggestion == null)
        {
            return NotFound();
        }
        
        var suggestionResource = SuggestionResourceFromEntityAssembler.ToResourceFromEntity(suggestion);
        return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, suggestionResource);
    }

    [HttpPut("{categoryId}/suggestions/{suggestionId}")]
    [SwaggerOperation(
        Summary = "Update a suggestion",
        Description = "Update a suggestion",
        OperationId = "UpdateSuggestion"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The suggestion was updated", typeof(SuggestionResource))]
    public async Task<IActionResult> UpdateSuggestion([FromRoute] int categoryId, [FromRoute] int suggestionId,
        [FromBody] UpdateSuggestionResource resource)
    {
        var suggestion =
            await categoryCommandService.Handle(new UpdateSuggestionCommand(categoryId, suggestionId,
                resource.Description));
        if (suggestion == null)
        {
            return NotFound();
        }

        var suggestionResource = SuggestionResourceFromEntityAssembler.ToResourceFromEntity(suggestion);
        return Ok(suggestionResource);
    }

    [HttpDelete("{categoryId}/suggestions/{suggestionId}")]
    [SwaggerOperation(
        Summary = "Delete a suggestion",
        Description = "Delete a suggestion",
        OperationId = "DeleteSuggestion"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The suggestion was deleted")]
    public async Task<IActionResult> DeleteSuggestion([FromRoute] int categoryId, [FromRoute] int suggestionId)
    {
        var success = await categoryCommandService.Handle(new DeleteSuggestionCommand(categoryId, suggestionId));
        if (!success)
        {
            return NotFound();
        }

        return NoContent();

    }
    
    
    [HttpDelete]
    [SwaggerOperation(
        Summary = "Delete a category",
        Description = "Delete a category",
        OperationId = "DeleteCategory"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The category was deleted")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var success = await categoryCommandService.Handle(new DeleteCategoryCommand(id));
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
    
}