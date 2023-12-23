namespace ReportsService.Domain.Dtos
{
    public class ReportDetailDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public int ReportId { get; set; }
    }
}
