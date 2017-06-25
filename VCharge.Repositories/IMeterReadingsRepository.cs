using System.Collections.Generic;
using VCharge.Models;

namespace VCharge.Repositories
{
    public interface IMeterReadingsRepository
    {
        IEnumerable<MeterReading> GetMeterReadings(string filePath);
    }
}
