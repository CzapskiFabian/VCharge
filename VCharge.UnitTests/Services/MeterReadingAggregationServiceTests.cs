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
            Assert.Equal(12, result.Count);
            Assert.Equal(new DateTime(2016, 1, 1).ToString(), result[0].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 2, 1).ToString(), result[1].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 3, 1).ToString(), result[2].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 4, 1).ToString(), result[3].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 5, 1).ToString(), result[4].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 6, 1).ToString(), result[5].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 7, 1).ToString(), result[6].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 8, 1).ToString(), result[7].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 9, 1).ToString(), result[8].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 10, 1).ToString(), result[9].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 11, 1).ToString(), result[10].DateMonthStart.ToString());
            Assert.Equal(new DateTime(2016, 12, 1).ToString(), result[11].DateMonthStart.ToString());
        }

        [Fact]
        public void GetMonthlyData_Should_Return_CorrectValuesForEachMonth()
        {
            // arrange

            // act
            var result = SystemUnderTest.GetMonthlyData(MeterReadingsSet1).ToList();

            // assert
            Assert.Equal(12, result.Count);
            Assert.Equal(MeterReadingsSet1[0].CumulativeConsumption, result[0].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet1[31].CumulativeConsumption, result[0].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet1[31].CumulativeConsumption -
                                   MeterReadingsSet1[0].CumulativeConsumption, result[0].TotalKwh());

            Assert.Equal(MeterReadingsSet1[31].CumulativeConsumption, result[1].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet1[60].CumulativeConsumption, result[1].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet1[60].CumulativeConsumption -
                       MeterReadingsSet1[31].CumulativeConsumption, result[1].TotalKwh());

            Assert.Equal(MeterReadingsSet1[335].CumulativeConsumption, result[11].KwhUsageAtMonthStart);
            Assert.Equal(MeterReadingsSet1[365].CumulativeConsumption, result[11].KwhUsageAtMonthEnd);
            Assert.Equal(MeterReadingsSet1[365].CumulativeConsumption -
                       MeterReadingsSet1[335].CumulativeConsumption, result[11].TotalKwh());
        }

        [Theory]
        [InlineData("2016/1/1","2016/1/3", 2.65)]
        [InlineData("2016/1/7","2016/2/12", 166.05)]
        [InlineData("2016/1/27","2016/2/2", 27.05)]
        [InlineData("2016/1/1","2016/12/31", 1456.45)]
        [InlineData("2016/1/1","2017/1/1", 1456.45)]
        public void GetUsageBetweenDates_Should_Return_CorrectTotalForGivenDates(string startDateText, string endDateText, decimal expected)
        {
            // arrange
            DateTime startDate = DateTime.ParseExact(startDateText, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endDateText, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);

            // act
            var result = SystemUnderTest.GetUsageBetweenDates(MeterReadingsSet1, startDate, endDate);

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
            Exception ex = Assert.Throws<Exception>(() => SystemUnderTest.GetUsageBetweenDates(MeterReadingsSet1, startDate, endDate));
            Assert.Equal("No Data For Chosen Time Period", ex.Message);
        }

        [Fact]
        public void GetUsageBetweenDates_Should_Throw_Exception_WhenInvalidDatesGiven()
        {
            // arrange
            DateTime startDate = new DateTime(2017, 1, 1);
            DateTime endDate = new DateTime(2016, 2, 2);

            // act and assert
            Exception ex = Assert.Throws<Exception>(() => SystemUnderTest.GetUsageBetweenDates(MeterReadingsSet1, startDate, endDate));
            Assert.Equal("Start date should be before the end date", ex.Message);
        }
    }
}
