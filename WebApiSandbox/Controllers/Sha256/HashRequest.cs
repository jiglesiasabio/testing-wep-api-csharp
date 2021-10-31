namespace WebApiSandbox.Controllers
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