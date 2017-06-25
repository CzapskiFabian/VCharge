using System;
using System.Collections.Generic;
using System.Linq;
using VCharge.Models;
using VCharge.Repositories;
using Xunit;

namespace VCharge.UnitTests
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
            Assert.Equal(215.75, meterReadings[0].CumulativeConsumption);
            Assert.Equal(new DateTime(2016, 1, 1), meterReadings[0].Date);
        }
    }
}