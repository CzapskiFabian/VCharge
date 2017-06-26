using System;
using System.Collections.Generic;
using System.Globalization;
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
                    CumulativeConsumption = decimal.Parse(v[1], CultureInfo.InvariantCulture.NumberFormat)
        }).ToList();

            return meterReadings;
        }

        public IEnumerable<MeterReading> GetMeterReadingsForDates(string filePath, DateTime startDate, DateTime endDate)
        {
            List<MeterReading> meterReadings = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(x => x.Split(','))
                .Select(v => new MeterReading
                {
                    Date = Convert.ToDateTime(v[0]),
                    CumulativeConsumption = decimal.Parse(v[1], CultureInfo.InvariantCulture.NumberFormat)
                })
                .Where(x=>x.Date>=startDate && x.Date<=endDate)
                .ToList();

            return meterReadings;
        }
    }
}
