using System;
using System.Collections.Generic;
using VCharge.Models;

namespace VCharge.Services
{
    public interface IMeterReaderService
    {
        ServiceResult<IEnumerable<MonthlySummary>> GetMonthlySummaries();
        ServiceResult<double> GetUsageForDates(DateTime startDate, DateTime endDate);
    }
}
