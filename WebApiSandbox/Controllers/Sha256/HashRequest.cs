namespace WebApiSandbox.Controllers.crypto.Sha256
{
    public class HashRequest
    {
        public HashRequest(string clearText)
        {
            ClearText = clearText;
        }

        public string ClearText { get; set; }
    }
}