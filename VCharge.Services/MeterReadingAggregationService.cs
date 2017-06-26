using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VCharge.Models;
using VCharge.Repositories;
using VCharge.Services.Extensions;

namespace VCharge.Services
{
    public class MeterReadingAggregationService : IMeterReadingAggregationService
    {
        public IEnumerable<MonthlySummary> GetMonthlyData(IEnumerable<MeterReading> dayReadings)
        {
            var monthlySummariesDict = new Dictionary<string, MonthlySummary>();

            foreach (var reading in dayReadings)
            {
                AddReadingToMonthlySummary(monthlySummariesDict, reading);
            }
            return monthlySummariesDict.Values;
        }

        private void AddReadingToMonthlySummary(Dictionary<string, MonthlySummary> monthlySummariesDict, MeterReading reading)
        {
            if (!monthlySummariesDict.ContainsKey(reading.Date.GetMonthKey()))
            {
                if (monthlySummariesDict.Count > 0)
                {
                    monthlySummariesDict[reading.Date.AddDays(-1).GetMonthKey()].KwhUsageAtMonthEnd =
                        reading.CumulativeConsumption;
                }
                monthlySummariesDict.Add(reading.Date.GetMonthKey(), new MonthlySummary
                {
                    DateMonthStart = new DateTime(reading.Date.Year, reading.Date.Month, 1),
                    KwhUsageAtMonthStart = reading.CumulativeConsumption
                });
            }
            monthlySummariesDict[reading.Date.GetMonthKey()].KwhUsageAtMonthEnd = reading.CumulativeConsumption;
        }

        public decimal GetUsageBetweenDates(IEnumerable<MeterReading> dayReadings, DateTime startDate, DateTime endDate)
        {
            var first = true;
            decimal firstReading = 0;
            decimal lastReading = 0;

            var meterReadings = dayReadings as IList<MeterReading> ?? dayReadings.ToList();
            if (!meterReadings.Any() || (meterReadings[0].Date > startDate))
                throw new Exception("No Data For Chosen Time Period");
            if (startDate > endDate)
                throw new Exception("Start date should be before the end date");

            foreach (var reading in meterReadings)
            {
                if (reading.Date >= startDate)
                {
                    if (first)
                    {

                        firstReading = lastReading = reading.CumulativeConsumption;
                        first = false;
                    }

                    lastReading = reading.CumulativeConsumption;
                }

                if (reading.Date > endDate)
                    break;
            }

            return lastReading - firstReading;
        }



    }
}
