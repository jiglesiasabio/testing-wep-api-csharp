namespace WebApiSandbox.Controllers
{
    public class HashResponse
    {
        public HashResponse(string hash)
        {
            Hash = hash;
        }

        public string Hash { get; set; }
    }
}