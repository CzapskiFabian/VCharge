using System;
using System.Collections.Generic;
using System.Text;

namespace VCharge.Services
{
    public class FilePathProvider : IFilePathProvider
    {
        public string GetPath()
        {
            return "MeterData.csv";
        }
    }
}
