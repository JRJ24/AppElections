

namespace Sadvo.Domain.BaseCommon
{
    public class OperationResult
    {
        public OperationResult() { 
            this.success = true;
        }

        public bool success { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }
        public int? statusCode { get; set; }

        public static OperationResult GetErrorResult(string message, dynamic? data = null, int? code = null)
        {
            return new()
            {
                success = false,
                message = message,
                data = data,
                statusCode = code
            };
        }

        public static OperationResult GetSuccesResult(dynamic data, string? message = null, int? code = null)
        {
            return new()
            {
                success = true,
                message = message,
                data = data,
                statusCode = code
            };
        }
    }
}
