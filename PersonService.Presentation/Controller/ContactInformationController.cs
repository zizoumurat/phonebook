﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.Features.ContactInformationFeatures.Commands.CreateContactInformation;
using PersonService.Application.Features.PersonFeatures.Commands.CreatePerson;
using PersonService.Application.Features.PersonFeatures.Commands.DeletePerson;
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

    [HttpDelete]
    public async Task<IActionResult> DeletePerson(string Id)
    {
        var response = await _mediator.Send(new DeletePersonCommand(Id));

        return Ok(response);
    }
}