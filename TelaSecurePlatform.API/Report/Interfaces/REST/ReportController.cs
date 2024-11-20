using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Domain.Model.Queries;
using TelaSecurePlatform.API.Report.Domain.Services;
using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

namespace TelaSecurePlatform.API.Report.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Reports Endpoints.")]
public class ReportsController(
    IReportCommandService reportCommandService,
    IReportQueryService reportQueryService
    ) : ControllerBase
{
    [HttpGet("{reportId:int}")]
    [SwaggerOperation(
        Summary = "Get report by id",
        Description = "Get report by id",
        OperationId = "GetReportById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The report with the given id", typeof(ReportResource))]
    public async Task<IActionResult> GetReportById([FromRoute] int reportId)
    {
        var report = await reportQueryService.Handle(new GetReportByIdQuery(reportId));
        if (report is null) return NotFound();
        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return Ok(reportResource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new report",
        Description = "Create a new report",
        OperationId = "CreateReport"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The report created", typeof(ReportResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The report could not be created")]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportResource resource)
    {
        var createReportCommand = CreateReportCommandFromResourceAssembler.ToCommandFromResource(resource);
        var report = await reportCommandService.Handle(createReportCommand);
        if (report is null) return BadRequest();
        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return CreatedAtAction(nameof(GetReportById), new { reportId = report.Id }, reportResource);
    }

    [HttpPut("{reportId:int}")]
    public async Task<IActionResult> UpdateReport([FromRoute] int reportId, UpdateReportResource resource)
    {
        var updateReportCommand = UpdateReportCommandFromResourceAssembler.ToCommand(reportId, resource);
        var report = await reportCommandService.Handle(updateReportCommand);
        if (report is null) return NotFound();
        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return Ok(reportResource);
    }

    [HttpDelete("{reportId:int}")]
    public async Task<IActionResult> DeleteReport([FromRoute] int reportId)
    {
        var deleteReportCommand = new DeleteReportCommand(reportId);
        var isDeleted = await reportCommandService.Handle(deleteReportCommand);
        if (!isDeleted) return NotFound();
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all reports",
        Description = "Get all reports",
        OperationId = "GetAllReports"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "All reports", typeof(IEnumerable<ReportResource>))]
    public async Task<IActionResult> GetAllReports()
    {
        var getAllReportsQuery = new GetAllReportsQuery();
        var reports = await reportQueryService.Handle(getAllReportsQuery);
        var reportResources = reports.Select(ReportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reportResources);
    }
}