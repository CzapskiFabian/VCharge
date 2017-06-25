using System;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using VCharge.Services;
using VCharge.Services.Extensions;
using Xunit;

namespace VCharge.UnitTests.Services
{
    public class MeterReadingAggregationServiceTests : MeterReadingAggregationServiceTestBase
    {

        [Fact]
        public void GetMonthlyData_Should_Return_ListOfMonthlySummaries()
        {
            // arrange

            // act
            var result = SystemUnderTest.GetMonthlyData(MeterReadingsSet1).ToList();

            // assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new DateTime(2016, 1, 1).ToString(), result[0].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 2, 1).ToString(), result[1].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 3, 1).ToString(), result[2].DateMonthStart.ToString());
        }

        [Fact]
        public void GetMonthlyData_Should_Return_CorrectValuesForEachMonth()
        {
            // arrange

            // act
            var result = SystemUnderTest.GetMonthlyData(MeterReadingsSet2).ToList();

            // assert
            Assert.Equal(4, result.Count);
            Assert.Equal(MeterReadingsSet2[0].CumulativeConsumption, result[0].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet2[2].CumulativeConsumption, result[0].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet2[2].CumulativeConsumption -
                                   MeterReadingsSet2[0].CumulativeConsumption, result[0].TotalKwh());

            Assert.Equal(MeterReadingsSet2[3].CumulativeConsumption, result[1].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet2[5].CumulativeConsumption, result[1].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet2[5].CumulativeConsumption -
                       MeterReadingsSet2[3].CumulativeConsumption, result[1].TotalKwh());

            Assert.Equal(MeterReadingsSet2[6].CumulativeConsumption, result[2].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet2[8].CumulativeConsumption, result[2].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet2[8].CumulativeConsumption -
                       MeterReadingsSet2[6].CumulativeConsumption, result[2].TotalKwh());

            Assert.Equal(MeterReadingsSet2[9].CumulativeConsumption, result[3].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet2[9].CumulativeConsumption, result[3].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet2[9].CumulativeConsumption -
                       MeterReadingsSet2[9].CumulativeConsumption, result[3].TotalKwh());
        }

        [Theory]
        [InlineData("2016/1/1","2016/1/2", 2)]
        [InlineData("2016/1/1","2016/1/3", 4)]
        [InlineData("2016/1/2","2016/1/3", 2)]
        [InlineData("2016/1/1","2016/2/1", 6)]
        [InlineData("2016/1/1","2016/3/1", 10)]
        [InlineData("2016/1/1","2017/3/1", 40)]
        public void GetUsageBetweenDates_Should_Return_CorrectTotalForGivenDates(string startDateText, string endDateText, double expected)
        {
            // arrange
            DateTime startDate = DateTime.ParseExact(startDateText, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endDateText, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);

            // act
            var result = SystemUnderTest.GetUsageBetweenDates(MeterReadingsSet2, startDate, endDate);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetUsageBetweenDates_Should_Throw_Exception_WhenNoDataForTimePeriod()
        {
            // arrange
            DateTime startDate = new DateTime(2015,1,1);
            DateTime endDate = new DateTime(2016, 2,2);

            // act and assert
            Exception ex = Assert.Throws<Exception>(() => SystemUnderTest.GetUsageBetweenDates(MeterReadingsSet2, startDate, endDate));
            Assert.Equal("No Data For Chosen Time Period", ex.Message);
        }

        [Fact]
        public void GetUsageBetweenDates_Should_Throw_Exception_WhenInvalidDatesGiven()
        {
            // arrange
            DateTime startDate = new DateTime(2017, 1, 1);
            DateTime endDate = new DateTime(2016, 2, 2);

            // act and assert
            Exception ex = Assert.Throws<Exception>(() => SystemUnderTest.GetUsageBetweenDates(MeterReadingsSet2, startDate, endDate));
            Assert.Equal("Start date should be before the end date", ex.Message);
        }
    }
}
