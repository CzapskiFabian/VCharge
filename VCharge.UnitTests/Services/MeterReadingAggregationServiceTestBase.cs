using System;
using System.Collections.Generic;
using VCharge.Models;
using VCharge.Services;

namespace VCharge.UnitTests.Services
{
    public class MeterReadingAggregationServiceTestBase : IDisposable
    {
        protected List<MeterReading> MeterReadingsSet1;
        protected List<MeterReading> MeterReadingsSet2;
        protected MeterReadingAggregationService SystemUnderTest;
        public MeterReadingAggregationServiceTestBase()
        {
            SystemUnderTest = new MeterReadingAggregationService();

            MeterReadingsSet1 = new List<MeterReading>
            {
                new MeterReading {CumulativeConsumption = 10, Date = new DateTime(2016, 1, 1)},
                new MeterReading {CumulativeConsumption = 16, Date = new DateTime(2016, 2, 10)},
                new MeterReading {CumulativeConsumption = 50, Date = new DateTime(2016, 3, 20)}
            };

            MeterReadingsSet2 = new List<MeterReading>
            {
                new MeterReading {CumulativeConsumption = 10, Date = new DateTime(2016, 1, 1)},
                new MeterReading {CumulativeConsumption = 12, Date = new DateTime(2016, 1, 2)},
                new MeterReading {CumulativeConsumption = 14, Date = new DateTime(2016, 1, 3)},

                new MeterReading {CumulativeConsumption = 16, Date = new DateTime(2016, 2, 1)},
                new MeterReading {CumulativeConsumption = 18, Date = new DateTime(2016, 2, 10)},
                new MeterReading {CumulativeConsumption = 20, Date = new DateTime(2016, 2, 15)},

                new MeterReading {CumulativeConsumption = 20, Date = new DateTime(2016, 3, 2)},
                new MeterReading {CumulativeConsumption = 20, Date = new DateTime(2016, 3, 6)},
                new MeterReading {CumulativeConsumption = 20, Date = new DateTime(2016, 3, 25)},

                new MeterReading {CumulativeConsumption = 50, Date = new DateTime(2016, 4, 15)}
            };

        }

        public void Dispose()
        {
        }
    }
}
