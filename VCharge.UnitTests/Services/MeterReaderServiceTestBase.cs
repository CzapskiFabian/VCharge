using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using VCharge.Repositories;
using VCharge.Services;

namespace VCharge.UnitTests.Services
{
    public class MeterReaderServiceTestBase : IDisposable
    {
        protected Mock<IFilePathProvider> MockFilePathProvider;
        protected Mock<IMeterReadingsRepository> MockRepo;
        protected Mock<IMeterReadingAggregationService> MockAggregateService;
        protected MeterReaderService SystemUnderTest;
        public MeterReaderServiceTestBase()
        {
            MockFilePathProvider = new Mock<IFilePathProvider>();
            MockRepo = new Mock<IMeterReadingsRepository>();
            MockAggregateService = new Mock<IMeterReadingAggregationService>();
            SystemUnderTest = new MeterReaderService(MockAggregateService.Object, MockRepo.Object, MockFilePathProvider.Object);

        }
        public void Dispose()
        {
        }
    }
}
