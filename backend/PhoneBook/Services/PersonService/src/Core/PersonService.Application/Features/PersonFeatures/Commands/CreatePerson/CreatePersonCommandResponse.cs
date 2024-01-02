namespace PersonService.Application.Features.PersonFeatures.Commands.CreatePerson
{
    public sealed record CreatePersonCommandResponse(string Id, string message = "Kayıt Başarılı.");
}