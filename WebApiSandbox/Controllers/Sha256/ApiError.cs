namespace WebApiSandbox.Controllers.Sha256
{
    public class ApiError
    {
        public ApiError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}