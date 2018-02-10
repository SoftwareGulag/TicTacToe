using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace TicTacToe.WebApi.Tests
{
    [TestFixture]
    public class GameControllerTests
    {
        [Test]
        public async Task NewGame_ReturnsEmptyBoard()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();
            using (var testServer = new TestServer(webHostBuilder))
            {
                var client = testServer.CreateClient();
                var response = await client.PostAsync("game/new", new StringContent(""));
                var responseContent = await response.Content.ReadAsStringAsync();
                var expectedJson = "{[_,_,_,_,_,_,_,_,_]}";

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent, Is.EqualTo(expectedJson));
            }
        }
    }
}