using System;

namespace VCharge.Models
{
    public class ServiceResult<TValue>
    {
        public TValue Value { get; }
        public ResultCode ResultCode {get;}
        public Exception Exception { get; }
        public string Message { get; }

        public ServiceResult(TValue value)
        {
            Value = value;
            ResultCode = ResultCode.Ok;
        }

        public ServiceResult(Exception ex, string message)
        {
            ResultCode=ResultCode.Error;
            Exception = ex;
            Message = message;
        }

    }
}
