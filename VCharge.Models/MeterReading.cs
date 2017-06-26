using System;

namespace VCharge.Models
{
    public class MeterReading
    {
        public DateTime Date { get; set; }
        public decimal CumulativeConsumption { get; set; }
    }
}
