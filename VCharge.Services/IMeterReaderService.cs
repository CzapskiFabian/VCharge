using System;
using System.Collections.Generic;
using VCharge.Models;
using VCharge.Models.Models;

namespace VCharge.Services
{
    public interface IMeterReaderService
    {
        ServiceResult<IEnumerable<MonthlySummary>> GetMonthlySummaries();
        ServiceResult<IEnumerable<MonthlySummary>> GetMonthlySummariesForDates(DateTime startDate, DateTime endDate);
        ServiceResult<decimal> GetUsageForDates(DateTime startDate, DateTime endDate);
    }
}
