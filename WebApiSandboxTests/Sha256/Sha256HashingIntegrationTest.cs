using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace WebApiSandboxTests.Sha256
{
    public class ApiWebApplicationFactory : WebApplicationFactory<WebApiSandbox.Startup>
    {
    }
    
    public class Sha256HashingIntegrationTest
    {
        private ApiWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new ApiWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task ItShouldHashAString()
        {
            // GIVEN
            var jsonRequest = new ByteArrayContent(Encoding.UTF8.GetBytes("{\"clearText\": \"Hello World\"}"));
            jsonRequest.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            // WHEN
            var response = await _client.PostAsync("/crypto/sha256", jsonRequest);

            // THEN
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            
            var actualResponseBody = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("{\"hash\":\"a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e\"}", actualResponseBody);
        }
        
        [Test]
        public async Task ItShouldReturnABadRequestErrorWhenTheProvidedClearTextIsAnEmptyString()
        {
            // GIVEN
            var jsonRequest = new ByteArrayContent(Encoding.UTF8.GetBytes("{\"clearText\": \"\"}"));
            jsonRequest.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            // WHEN
            var response = await _client.PostAsync("/crypto/sha256", jsonRequest);

            // THEN
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            
            var actualResponseBody = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("{\"errorCode\":\"400\",\"errorMessage\":\"String cannot be empty\"}", actualResponseBody);
        }
    }
}