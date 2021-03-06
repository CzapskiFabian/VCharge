﻿using System;
using System.Collections.Generic;
using VCharge.Models;
using VCharge.Models.Models;

namespace VCharge.Repositories
{
    public interface IMeterReadingsRepository
    {
        IEnumerable<MeterReading> GetMeterReadings(string filePath);
        IEnumerable<MeterReading> GetMeterReadingsForDates(string filePath, DateTime startDate, DateTime endDate);
    }
}
