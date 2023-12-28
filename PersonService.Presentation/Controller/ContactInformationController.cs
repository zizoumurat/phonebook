using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;
using PersonService.Application.Features.ContactInformationFeatures.Commands.DeleteContactInformation;
using PersonService.Application.Features.ContactInformationFeatures.Queries.Report;
using PersonService.Presentation.Abstraction;

namespace PersonService.Presentation.Controller;

public class ContactInformationController : ApiController
{
    public ContactInformationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCICommand request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet]
    [Route("report")]
    public async Task<IActionResult> Report()
    {
        ReportQuery request = new();
        var response = await _mediator.Send(request);

        return Ok(response.reportList);
    }

    [HttpDelete("{personId}/{id}")]
    public async Task<IActionResult> Delete(string 	string id)
    {
        var response = await _mediator.Send(new DeleteCICommand(personId, id));

        return Ok(response);
    }
}
