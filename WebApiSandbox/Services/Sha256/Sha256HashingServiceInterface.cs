using System.Security.Policy;

namespace WebApiSandbox.Services
{
    public interface Sha256HashingServiceInterface
    {
        public string Hash(string clearText);
    }
}