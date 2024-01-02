namespace ReportsService.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsComplated { get; set; }

        public virtual List<ReportDetail> Details { get; set; } = new();
    }
}
