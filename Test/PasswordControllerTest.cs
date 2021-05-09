using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using WebApi;
using System.Threading.Tasks;
using Xunit;
using WebApi.Model;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace Test
{
    public class PasswordControllerTest
    {
        private readonly HttpClient _client;

        public PasswordControllerTest()
        {
            var server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory()]
        [InlineData("AbTp9!fok")]
        public async Task PostPasswordTest(string pass)
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"),"/Password");
            request.Content = BuildPasswordJson(pass);
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Theory()]
        [InlineData("AbTph!fok")]
        public async Task NegativePostPasswordTest(string pass)
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"),"/Password");
            request.Content = BuildPasswordJson(pass);
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.BadRequest,response.StatusCode);
        }

        private StringContent BuildPasswordJson(string pass)
        {
            var userPass = new UserPassword(pass);
            return new StringContent(JsonConvert.SerializeObject(userPass),Encoding.UTF8,"application/json");
        }
    }
}
