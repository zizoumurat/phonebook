using AutoMapper;
using Moq;

namespace ReportsService.UnitTest.Base
{
    public class BaseFixture
    {
        protected readonly Mock<IMapper> _mapper;

        public BaseFixture()
        {
            _mapper = new();
        }
    }
}
