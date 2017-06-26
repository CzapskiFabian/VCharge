using System;
using System.Collections.Generic;
using System.Linq;
using VCharge.Models;
using VCharge.Models.Models;
using VCharge.Repositories;
using Xunit;

namespace VCharge.UnitTests.Repositories
{
    public class MeterReadingsRepositoryTests
    {
        [Fact]
        public void GetMeterReadings_Should_Return_ListOfMeterReadings()
        {
            // arrange
            var path = "TestData/MeterData.csv";
            MeterReadingRepository meterReadingsRepository = new MeterReadingRepository();

            // act
            var result = meterReadingsRepository.GetMeterReadings(path);

            // assert
            var meterReadings = result as IList<MeterReading> ?? result.ToList();
            Assert.Equal(366, meterReadings.Count());
            Assert.Equal((decimal)215.75, meterReadings[0].CumulativeConsumption);
            Assert.Equal(new DateTime(2016, 1, 1), meterReadings[0].Date);
        }

        [Theory]
        [InlineData("2016/1/1", 215.75, "2016/2/1", 338.65)]
        [InlineData("2016/1/14", 258.25, "2016/2/15", 403.85)]
        [InlineData("2016/1/1", 215.75, "2016/6/1", 775.45)]
        public void GetMeterReadingsForDates_Should_Return_ListOfMeterReadingsBetweenDates(string startDateString, decimal startExpectedValue, string endDateString, decimal endExpectedValue)
        {
            // arrange
            var path = "TestData/MeterData.csv";
            MeterReadingRepository meterReadingsRepository = new MeterReadingRepository();
            var startDate = DateTime.ParseExact(startDateString, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(endDateString, "yyyy/M/d", System.Globalization.CultureInfo.InvariantCulture);
            ;
            // act
            var result = meterReadingsRepository.GetMeterReadingsForDates(path, startDate, endDate);

            // assert
            var meterReadings = result as IList<MeterReading> ?? result.ToList();
            Assert.Equal((endDate - startDate).TotalDays, meterReadings.Count-1);
            Assert.Equal(startExpectedValue, meterReadings[0].CumulativeConsumption);
            Assert.Equal(endExpectedValue, meterReadings[meterReadings.Count-1].CumulativeConsumption);
        }
    }
}