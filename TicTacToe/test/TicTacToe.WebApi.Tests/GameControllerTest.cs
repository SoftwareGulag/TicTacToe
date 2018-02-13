using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace TicTacToe.WebApi.Tests
{
    [TestFixture]
    public class GameControllerTest
    {
        private IWebHostBuilder _webHostBuilder;

        [SetUp]
        public void Setup()
        {
            _webHostBuilder = new WebHostBuilder()
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>();
        }

        [Test]
        public async Task NewGame_ReturnsEmptyBoard()
        {
            using (var testServer = new TestServer(_webHostBuilder))
            {
                var client = testServer.CreateClient();
                var response = await client.PostAsync("game/new", new StringContent(""));
                var responseContent = await response.Content.ReadAsStringAsync();
                var expectedJson = "{[_,_,_,_,_,_,_,_,_]}";

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent, Is.EqualTo(expectedJson));
            }
        }

        [Test]
        public async Task Move_WhenOneMoveWasMade_ReturnsBoardWith_o()
        {
            using (var testServer = new TestServer(_webHostBuilder))
            {
                var client = testServer.CreateClient();
                await client.PostAsync("game/new", new StringContent(""));
                var response = await client.PostAsync("game/move/0", null );
                var responseContent = await response.Content.ReadAsStringAsync();

                var expectedJson = "{[o,_,_,_,_,_,_,_,_]}";

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent, Is.EqualTo(expectedJson));
            }
        }

        [Test]
        public async Task Move_WhenTwoMoveWereMade_ReturnsBoardWith_ox()
        {
            using (var testServer = new TestServer(_webHostBuilder))
            {
                var client = testServer.CreateClient();
                await client.PostAsync("game/new", null);
                await client.PostAsync("game/move/0", null);
                var response = await client.PostAsync("game/move/3", null);
                var responseContent = await response.Content.ReadAsStringAsync();

                var expectedJson = "{[o,_,_,x,_,_,_,_,_]}";

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent, Is.EqualTo(expectedJson));
            }
        }
    }
}