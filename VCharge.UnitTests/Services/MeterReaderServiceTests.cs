using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using VCharge.Models;
using VCharge.Repositories;
using VCharge.Services;
using Xunit;

namespace VCharge.UnitTests.Services
{
    public class MeterReaderServiceTests : MeterReaderServiceTestBase
    {
        [Fact]
        public void GetMonthlySummaries_Should_Return_ResultOfCallingAppropriateServices()
        {
            // arrange
            MockFilePathProvider.Setup(x => x.GetPath()).Returns("path");
            var meterReadings = new List<MeterReading>();
            MockRepo.Setup(x => x.GetMeterReadings("path")).Returns(meterReadings);
            var monthlyData = new List<MonthlySummary>();
            MockAggregateService.Setup(x => x.GetMonthlyData(meterReadings)).Returns(monthlyData);

            // act
            var result = SystemUnderTest.GetMonthlySummaries();

            // assert
            Assert.Equal(monthlyData, result.Value);
            Assert.Equal(ResultCode.Ok, result.ResultCode);
        }

        [Fact]
        public void GetMonthlySummaries_Should_Return_ErrorResultOnInternalServerException()
        {
            // arrange
            MockFilePathProvider.Setup(x => x.GetPath()).Throws(new Exception());

            // act
            var result = SystemUnderTest.GetMonthlySummaries();

            // assert
            Assert.Equal(ResultCode.Error, result.ResultCode);
        }

        [Fact]
        public void GetUsageForDates_Should_Return_ResultOfCallingAppropriateServices()
        {
            // arrange
            MockFilePathProvider.Setup(x => x.GetPath()).Returns("path");
            var meterReadings = new List<MeterReading>();
            MockRepo.Setup(x => x.GetMeterReadings("path")).Returns(meterReadings);
            var usage = 2;
            var startDate = new DateTime();
            var endDate = new DateTime();
            MockAggregateService.Setup(x => x.GetUsageBetweenDates(meterReadings, startDate, endDate)).Returns(usage);

            // act
            var result = SystemUnderTest.GetUsageForDates(startDate, endDate);

            // assert
            Assert.Equal(usage, result.Value);
            Assert.Equal(ResultCode.Ok, result.ResultCode);
        }

        [Fact]
        public void GetUsageForDates_Should_Return_ErrorResultOnInternalServerException()
        {
            // arrange
            MockFilePathProvider.Setup(x => x.GetPath()).Throws(new Exception());

            // act
            var result = SystemUnderTest.GetUsageForDates(new DateTime(), new DateTime());

            // assert
            Assert.Equal(ResultCode.Error, result.ResultCode);
        }
    }
}
