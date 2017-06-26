using System;
using System.Collections.Generic;
using System.Text;
using VCharge.Services;
using Xunit;

namespace VCharge.UnitTests.Services
{
    public class FilePathProviderTests
    {
        [Fact]
        public void GetPath_Should_Return_CorrectPath()
        {
            // arrange
            FilePathProvider service = new FilePathProvider();

            // act
            var result = service.GetPath();

            // assert
            Assert.Equal("../VCharge.UnitTests/TestData/MeterData.csv", result);
        }
    }
}
