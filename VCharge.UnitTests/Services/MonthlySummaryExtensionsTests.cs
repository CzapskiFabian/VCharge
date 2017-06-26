using System;
using System.Collections.Generic;
using System.Text;
using VCharge.Models;
using VCharge.Services.Extensions;
using Xunit;

namespace VCharge.UnitTests.Services
{
    public class MonthlySummaryExtensionsTests
    {
        [Theory]
        [InlineData(10.0, 10.0, 0.0)]
        [InlineData(10.0, 12.0, 2.0)]
        [InlineData(10.0, 100.0, 90.0)]
        [InlineData(0.5, 10.0, 9.5)]
        [InlineData(2.0, 18.0, 16.0)]
        public void TotalKwh_Should_Return_CorrentValue(decimal startValue, decimal endValue, decimal expected)
        {
            // arrange
            var monthlySummary = new MonthlySummary
            {
                KwhUsageAtMonthStart = startValue,
                KwhUsageAtMonthEnd = endValue
            };

            // act
            var result = monthlySummary.TotalKwh();

            // assert
            Assert.Equal(expected, result);
        }
    }
}
