using System;
using System.Collections.Generic;
using System.Text;

namespace VCharge.Services
{
    public class FilePathProvider : IFilePathProvider
    {
        public string GetPath()
        {
            return "../VCharge.UnitTests/TestData/MeterData.csv";
        }
    }
}
