namespace ReportsService.Domain.Entities
{
    public class ReportDetail
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public int ReportId { get; set; }

        public virtual Report Report { get; set; }
    }
}
