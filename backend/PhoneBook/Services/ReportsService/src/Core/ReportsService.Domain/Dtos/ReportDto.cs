namespace ReportsService.Domain.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsComplated { get; set; }
    }
}
