using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.Features.PersonFeatures.Commands.CreatePerson;
using PersonService.Application.Features.PersonFeatures.Commands.DeletePerson;
using PersonService.Application.Features.PersonFeatures.Queries.GetAllPerson;
using PersonService.Application.Features.PersonFeatures.Queries.GetPerson;
using PersonService.Presentation.Abstraction;

namespace PersonService.Presentation.Controller
{
    public class PersonController : ApiController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllPersonQuery query = new();
            var response = await _mediator.Send(query);

            return Ok(response.personList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            GetPersonQuery query = new(id);
            var response = await _mediator.Send(query);

            return Ok(response.person);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(string Id)
        {
            var response = await _mediator.Send(new DeletePersonCommand(Id));

            return Ok(response);
        }
    }
}
