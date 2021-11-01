namespace WebApiSandbox.Controllers.crypto.Sha256
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