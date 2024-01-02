namespace PersonService.Domain.Dtos
{
    public class PersonDetailDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public List<ContactInformationDto> ContactInformation { get; set; }
    }
}
