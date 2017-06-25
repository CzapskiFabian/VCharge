using System;
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
    }

}
