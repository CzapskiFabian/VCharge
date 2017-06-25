using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VCharge.Models;
using VCharge.Repositories;

namespace VCharge.Services
{
    public class MeterReadingAggregationService : IMeterReadingAggregationService
    {
        public IEnumerable<MonthlySummary> GetMonthlyData(IEnumerable<MeterReading> dayReadings)
        {
            // Ealierst date in the month is the base line

            var monthlySummariesDict = new Dictionary<int, MonthlySummary>();

            foreach (var reading in dayReadings)
            {
                if (!monthlySummariesDict.ContainsKey(reading.Date.Month))
                {
                    monthlySummariesDict.Add(reading.Date.Month, new MonthlySummary
                    {
                        DateMonthStart = new DateTime(reading.Date.Year, reading.Date.Month, 1),
                        KwhUsageAtMonthStart = reading.CumulativeConsumption
                    });
                }
                monthlySummariesDict[reading.Date.Month].KwhUsageAtMonthEnd = reading.CumulativeConsumption;
            }

            return monthlySummariesDict.Values;
        }

        public double GetUsageBetweenDates(IEnumerable<MeterReading> dayReadings, DateTime startDate, DateTime endDate)
        {
            var first = true;
            var firstReading = 0.0;
            var lastReading = 0.0;

            var meterReadings = dayReadings as IList<MeterReading> ?? dayReadings.ToList();
            if (!meterReadings.Any() || (meterReadings[0].Date > startDate))
                throw new Exception("No Data For Chosen Time Period");
            if (startDate > endDate)
                throw new Exception("Start date should be before the end date");

            foreach (var reading in meterReadings)
            {
                if (first && reading.Date>=startDate)
                {

                    firstReading = lastReading = reading.CumulativeConsumption;
                    first = false;
                }

                if (reading.Date > endDate)
                    break;

                lastReading = reading.CumulativeConsumption;
            }

            return lastReading - firstReading;
        }
    }
}
