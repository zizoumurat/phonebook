using PersonService.Application.Messaging;
using PersonService.Application.Services;

namespace PersonService.Application.Features.ContactInformationFeatures.Queries.Report
{
    public class ReportQueryHandler : IQueryHandler<ReportQuery, ReportQueryResponse>
    {
        private readonly IContactInformaionService _contactInformationService;

        public ReportQueryHandler(IContactInformaionService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        public async Task<ReportQueryResponse> Handle(ReportQuery request, CancellationToken cancellationToken)
        {
            var list = await _contactInformationService.GetReportList();

            return new(list);
        }
    }
}
