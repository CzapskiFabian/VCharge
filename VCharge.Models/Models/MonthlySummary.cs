using System;

namespace VCharge.Models.Models
{
    public class MonthlySummary
    {
        public DateTime DateMonthStart { get; set; }
        public decimal KwhUsageAtMonthStart { get; set; }
        public decimal KwhUsageAtMonthEnd { get; set; }
    }
}
