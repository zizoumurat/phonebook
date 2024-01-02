namespace ReportsService.Domain.Dtos
{
    public class ReportWithDetailDto
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsComplated { get; set; }

        public virtual List<ReportDetailDto> Details { get; set; } = new();
    }
}
