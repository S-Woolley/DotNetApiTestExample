using NUnit.Framework;
using Petstore.Api;
using System.Net;

namespace DotNetApiTestExample
{
    public class CreateUsersTests
    {

        [Test]
        public async Task LoginUser()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://localhost:8888"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            // Create a client handler that uses the proxy
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            using var httpClient = new HttpClient(httpClientHandler);

            var apiClient = new Client(httpClient);

            var result = await apiClient.LoginUserAsync("test", "abc123");
            Console.Out.WriteLine(result);
            //Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task GetPEts()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://localhost:8888"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            // Create a client handler that uses the proxy
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            using var httpClient = new HttpClient(httpClientHandler);

            var apiClient = new Client(httpClient);
            var pets = new List<string>();
            pets.Add("available");
            var result = await apiClient.FindPetsByStatusAsync(pets);
            Console.Out.WriteLine(result);
            //Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateUser()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://localhost:8888"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            // Create a client handler that uses the proxy
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            using var httpClient = new HttpClient(httpClientHandler);

            var apiClient = new Client(httpClient);

            var result = await apiClient.CreateUserAsync(new { Steven = "Woolley" }, CancellationToken.None);
            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateUserHappyPath()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://localhost:8888"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            // Create a client handler that uses the proxy
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            using var httpClient = new HttpClient(httpClientHandler);

            var apiClient = new Client(httpClient);

            var user = new User { Id = 123,
                Username = "SuperDude",
                FirstName = "Clark",
                LastName = "Kent", 
                Email = "dfasfd@test.com", 
                Password = "asdfasf", 
                Phone = "123" };

            var result = await apiClient.CreateUserAsync((object)user, CancellationToken.None);
            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateUserHappyPath2()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://localhost:8888"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            // Create a client handler that uses the proxy
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            using var httpClient = new HttpClient(httpClientHandler);

            var apiClient = new Client(httpClient);

            var user = new User
            {
                Id = 123,
                Username = "SuperDude",
                FirstName = "Clark",
                LastName = "Kent",
                Email = "dfasfd@test.com",
                Password = "asdfasf",
                Phone = "123"
            };

            await apiClient.CreateUserAsync(user, CancellationToken.None);
        }
    }
}