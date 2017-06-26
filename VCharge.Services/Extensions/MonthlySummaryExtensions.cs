using System;
using System.Collections.Generic;
using System.Text;
using VCharge.Models;
using VCharge.Models.Models;

namespace VCharge.Services.Extensions
{
    public static class MonthlySummaryExtensions
    {
        public static decimal TotalKwh(this MonthlySummary summary)
        {
            return summary.KwhUsageAtMonthEnd - summary.KwhUsageAtMonthStart;
        }

        public static string GetMonthKey(this DateTime dateTime)
        {
            return dateTime.Year + "/" + dateTime.Month;
        }
    }
}
