using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VCharge.Models;

namespace VCharge.Repositories
{
    public class MeterReadingRepository : IMeterReadingsRepository
    {
        public IEnumerable<MeterReading> GetMeterReadings(string filePath)
        {
            List<MeterReading> meterReadings = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(x => x.Split(','))
                .Select(v=>new MeterReading
                {
                    Date=Convert.ToDateTime(v[0]),
                    CumulativeConsumption = Convert.ToDouble(v[1])
                }).ToList();

            return meterReadings;
        }
    }
}
