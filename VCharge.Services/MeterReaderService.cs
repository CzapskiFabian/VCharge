using System;
using System.Collections.Generic;
using System.Text;
using VCharge.Models;
using VCharge.Models.Models;
using VCharge.Repositories;

namespace VCharge.Services
{
    public class MeterReaderService : IMeterReaderService
    {
        private readonly IMeterReadingAggregationService _meterReadingAggregationService;
        private readonly IMeterReadingsRepository _meterReadingsRepository;
        private readonly IFilePathProvider _filePathProvider;
        public MeterReaderService(IMeterReadingAggregationService meterReadingAggregationService, IMeterReadingsRepository meterReadingsRepository, IFilePathProvider filePathProvider)
        {
            _meterReadingAggregationService = meterReadingAggregationService;
            _meterReadingsRepository = meterReadingsRepository;
            _filePathProvider = filePathProvider;
        }

        public ServiceResult<IEnumerable<MonthlySummary>> GetMonthlySummaries()
        {
            try
            {
                var pathToFile = _filePathProvider.GetPath();
                var meterReadings = _meterReadingsRepository.GetMeterReadings(pathToFile);
                var monthlySummaries = _meterReadingAggregationService.GetMonthlyData(meterReadings);

                return new ServiceResult<IEnumerable<MonthlySummary>>(monthlySummaries);
            }
            catch (Exception ex)
            {
                // TODO: Log exception. Perhaps out of scope for this project

                return new ServiceResult<IEnumerable<MonthlySummary>>(ex, "Server Error");
            }

        }

        public ServiceResult<decimal> GetUsageForDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                var pathToFile = _filePathProvider.GetPath();
                var meterReadings = _meterReadingsRepository.GetMeterReadings(pathToFile);
                var monthlySummaries = _meterReadingAggregationService.GetUsageBetweenDates(meterReadings, startDate, endDate);

                return new ServiceResult<decimal>(monthlySummaries);
            }
            catch (Exception ex)
            {
                // TODO: Log exception. Perhaps out of scope for this project

                return new ServiceResult<decimal>(ex, "Server Error");
            }
        }

        public ServiceResult<IEnumerable<MonthlySummary>> GetMonthlySummariesForDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                var pathToFile = _filePathProvider.GetPath();
                var meterReadings = _meterReadingsRepository.GetMeterReadingsForDates(pathToFile, startDate, endDate);
                var monthlySummaries = _meterReadingAggregationService.GetMonthlyData(meterReadings);

                return new ServiceResult<IEnumerable<MonthlySummary>>(monthlySummaries);
            }
            catch (Exception ex)
            {
                // TODO: Log exception. Perhaps out of scope for this project

                return new ServiceResult<IEnumerable<MonthlySummary>>(ex, "Server Error");
            }
        }

    }
}
