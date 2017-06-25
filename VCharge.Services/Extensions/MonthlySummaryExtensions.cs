using System;
using System.Collections.Generic;
using System.Text;
using VCharge.Models;

namespace VCharge.Services.Extensions
{
    public static class MonthlySummaryExtensions
    {
        public static double TotalKwh(this MonthlySummary summary)
        {
            return summary.KwhUsageAtMonthEnd - summary.KwhUsageAtMonthStart;
        }
    }
}
