using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Domain.Model.Queries;
using TelaSecurePlatform.API.Report.Domain.Services;
using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

namespace TelaSecurePlatform.API.Summary.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Summaries Endpoints.")]
public class SummariesController(
    ISummaryCommandService summaryCommandService,
    ISummaryQueryService summaryQueryService
    ) : ControllerBase
{
    [HttpGet("{summaryId:int}")]
    [SwaggerOperation(
        Summary = "Get summary by id",
        Description = "Get summary by id",
        OperationId = "GetSummaryById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The summary with the given id", typeof(SummaryResource))]
    public async Task<IActionResult> GetSummaryById([FromRoute] int summaryId)
    {
        var summary = await summaryQueryService.Handle(new GetSummaryByIdQuery(summaryId));
        if (summary is null) return NotFound();
        var summaryResource = SummaryResourceFromEntityAssembler.ToResourceFromEntity(summary);
        return Ok(summaryResource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new summary",
        Description = "Create a new summary",
        OperationId = "CreateSummary"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The summary created", typeof(SummaryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The summary could not be created")]
    public async Task<IActionResult> CreateSummary([FromBody] CreateSummaryResource resource)
    {
        var createSummaryCommand = CreateSummaryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var summary = await summaryCommandService.Handle(createSummaryCommand);
        if (summary is null) return BadRequest();
        var summaryResource = SummaryResourceFromEntityAssembler.ToResourceFromEntity(summary);
        return CreatedAtAction(nameof(GetSummaryById), new { summaryId = summary.Id }, summaryResource);
    }

    [HttpPut("{summaryId:int}")]
    public async Task<IActionResult> UpdateSummary([FromRoute] int summaryId, UpdateSummaryResource resource)
    {
        var updateSummaryCommand = UpdateSummaryCommandFromResourceAssembler.ToCommand(summaryId, resource);
        var summary = await summaryCommandService.Handle(updateSummaryCommand);
        if (summary is null) return NotFound();
        var summaryResource = SummaryResourceFromEntityAssembler.ToResourceFromEntity(summary);
        return Ok(summaryResource);
    }

    [HttpDelete("{summaryId:int}")]
    public async Task<IActionResult> DeleteSummary([FromRoute] int summaryId)
    {
        var deleteSummaryCommand = new DeleteSummaryCommand(summaryId);
        var isDeleted = await summaryCommandService.Handle(deleteSummaryCommand);
        if (!isDeleted) return NotFound();
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all summaries",
        Description = "Get all summaries",
        OperationId = "GetAllSummaries"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "All summaries", typeof(IEnumerable<SummaryResource>))]
    public async Task<IActionResult> GetAllSummaries()
    {
        var getAllSummariesQuery = new GetAllSummariesQuery();
        var summaries = await summaryQueryService.Handle(getAllSummariesQuery);
        var summaryResources = summaries.Select(summary => SummaryResourceFromEntityAssembler.ToResourceFromEntity(summary));        return Ok(summaryResources);
    }
}