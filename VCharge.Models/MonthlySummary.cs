using System;
using System.Collections.Generic;

namespace VCharge.Models
{
    public class MonthlySummary
    {
        public DateTime DateMonthStart { get; set; }
        public double KwhUsageAtMonthStart { get; set; }
        public double KwhUsageAtMonthEnd { get; set; }
    }
}
