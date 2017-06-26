using System;
using System.Collections.Generic;

namespace VCharge.Models
{
    public class MonthlySummary
    {
        public DateTime DateMonthStart { get; set; }
        public decimal KwhUsageAtMonthStart { get; set; }
        public decimal KwhUsageAtMonthEnd { get; set; }
    }
}
