using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using VCharge.Models;
using VCharge.Services;

namespace VCharge.UnitTests.Services
{
    public class MeterReadingAggregationServiceTestBase : IDisposable
    {
        protected List<MeterReading> MeterReadingsSet1;
        protected MeterReadingAggregationService SystemUnderTest;
        public MeterReadingAggregationServiceTestBase()
        {
            SystemUnderTest = new MeterReadingAggregationService();

            MeterReadingsSet1 = File.ReadAllLines("TestData/MeterData.csv")
                .Skip(1)
                .Select(x => x.Split(','))
                .Select(v => new MeterReading
                {
                    Date = Convert.ToDateTime(v[0]),
                    CumulativeConsumption = decimal.Parse(v[1], CultureInfo.InvariantCulture.NumberFormat)
        }).ToList();
            //MeterReadingsSet1 = new List<MeterReading>
            //{
            //    new MeterReading {CumulativeConsumption = 10, Date = new DateTime(2016, 1, 1)},
            //    new MeterReading {CumulativeConsumption = 12, Date = new DateTime(2016, 1, 31)},

            //    new MeterReading {CumulativeConsumption = 16, Date = new DateTime(2016, 2, 1)},
            //    new MeterReading {CumulativeConsumption = 18, Date = new DateTime(2016, 2, 29)},

            //    new MeterReading {CumulativeConsumption = 20, Date = new DateTime(2016, 3, 1)},
            //    new MeterReading {CumulativeConsumption = 20, Date = new DateTime(2016, 3, 31)},

            //    new MeterReading {CumulativeConsumption = 50, Date = new DateTime(2016, 4, 1)},
            //    new MeterReading {CumulativeConsumption = 51, Date = new DateTime(2016, 4, 2)},
            //    new MeterReading {CumulativeConsumption = 52, Date = new DateTime(2016, 4, 3)},
            //    new MeterReading {CumulativeConsumption = 53, Date = new DateTime(2016, 4, 4)},

            //    new MeterReading {CumulativeConsumption = 54, Date = new DateTime(2016, 4, 27)},
            //    new MeterReading {CumulativeConsumption = 55, Date = new DateTime(2016, 4, 28)},
            //    new MeterReading {CumulativeConsumption = 56, Date = new DateTime(2016, 4, 29)},
            //    new MeterReading {CumulativeConsumption = 57, Date = new DateTime(2016, 4, 30)},
            //    new MeterReading {CumulativeConsumption = 58, Date = new DateTime(2016, 5, 1)},


            //};

        }

        public void Dispose()
        {
        }
    }
}
