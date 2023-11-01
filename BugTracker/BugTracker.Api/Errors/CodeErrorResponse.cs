namespace BugTracker.Api.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Sent request has errors",
                401 => "You have no authorization to access this resource",
                402 => "Requested resource not found",
                500 => "Server error",
                _ => string.Empty
            };
        }
    }
}
