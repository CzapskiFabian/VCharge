using System;
using System.Collections.Generic;
using VCharge.Models;
using VCharge.Models.Models;

namespace VCharge.Services
{
    public interface IMeterReadingAggregationService
    {
        IEnumerable<MonthlySummary> GetMonthlyData(IEnumerable<MeterReading> dayReadings);
        decimal GetUsageBetweenDates(IEnumerable<MeterReading> dayReadings, DateTime startDate, DateTime endDate);
    }
}
