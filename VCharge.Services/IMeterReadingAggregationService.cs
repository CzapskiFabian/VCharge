using System.Collections.Generic;
using VCharge.Models;

namespace VCharge.Services
{
    public interface IMeterReadingAggregationService
    {
        IEnumerable<MonthlySummary> GetMonthlyData(IEnumerable<MeterReading> dayReadings);
    }
}
