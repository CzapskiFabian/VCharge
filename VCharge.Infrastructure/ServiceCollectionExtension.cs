using Microsoft.Extensions.DependencyInjection;
using VCharge.Repositories;
using VCharge.Services;

namespace VCharge.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMeterDataRepository(this IServiceCollection services)
        {
            services.AddTransient<IMeterReadingsRepository, MeterReadingRepository>();
            return services;
        }

        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IFilePathProvider, FilePathProvider>();
            services.AddTransient<IMeterReadingAggregationService, MeterReadingAggregationService>();
            services.AddTransient<IMeterReaderService, MeterReaderService>();
            return services;
        }


    }

}
