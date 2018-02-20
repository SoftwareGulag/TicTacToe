using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using TicTacToe.WebApi.Boundary;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Tests
{
    [TestFixture]
    public class GameControllerTest
    {
        private IWebHostBuilder _webHostBuilder;
        private TestServer _testServer;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _webHostBuilder = new WebHostBuilder()
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>();
            _testServer = new TestServer(_webHostBuilder);
            _httpClient = _testServer.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _testServer.Dispose();
        }

        [Test]
        public async Task NewGame_ReturnsEmptyBoard()
        {
            var expectedGameState = new GameStateResponse("{[_,_,_,_,_,_,_,_,_]}");
            var response = await PostNewGameRequest();
            await AssertResponse(response, expectedGameState);
        }

        [Test]
        public async Task Move_WhenOneMoveWasMade_ReturnsBoardWith_o()
        {
            var expectedGameState = new GameStateResponse("{[o,_,_,_,_,_,_,_,_]}", GameOutcome.OpenOutcome);
            await PostNewGameRequest();
            var response = await PostMoveRequest(0);
            await AssertResponse(response, expectedGameState);
        }

        [Test]
        public async Task Move_WhenSecondMoveIsTheSameAsFirst_ReturnsBadRequest()
        {
            await PostNewGameRequest();
            await PostMoveRequest(0);
            var response = await PostMoveRequest(0);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Move_WhenSecondCellIdIsOutsideOfBoardRange_ReturnsBadRequest()
        {
            await PostNewGameRequest();
            var response = await PostMoveRequest(10);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Move_WhenTwoMoveWereMade_ReturnsBoardWith_ox()
        {
            var expectedGameState = new GameStateResponse("{[o,_,_,x,_,_,_,_,_]}", GameOutcome.OpenOutcome);
            await PostNewGameRequest();
            await PostMoveRequest(0);
            var response = await PostMoveRequest(3);
            await AssertResponse(response, expectedGameState);
        }

        [Test]
        public async Task Move_When_o_HasWon_ReturnsGameStateWithOHasWonTrue()
        {
            var expectedGameState = new GameStateResponse("{[o,o,o,x,_,x,_,_,_]}", GameOutcome.OHasWon);
            await PostNewGameRequest();
            await PostMoveRequest(0);
            await PostMoveRequest(3);
            await PostMoveRequest(1);
            await PostMoveRequest(5);
            var response = await PostMoveRequest(2);
            await AssertResponse(response, expectedGameState);
        }

        [Test]
        public async Task Move_WhenGameEndedWithDraw_ReturnsGameStateWithDrwaOutcome()
        {
            var expectedGameState = new GameStateResponse("{[o,x,o,o,x,x,x,o,o]}", GameOutcome.Draw);
            await PostNewGameRequest();
            await PostMoveRequest(0);
            await PostMoveRequest(1);
            await PostMoveRequest(2);
            await PostMoveRequest(4);
            await PostMoveRequest(3);
            await PostMoveRequest(5);
            await PostMoveRequest(7);
            await PostMoveRequest(6);
            var response = await PostMoveRequest(8);
            await AssertResponse(response, expectedGameState);
        }

        private static async Task AssertResponse(HttpResponseMessage response, GameStateResponse expectedGameState)
        {
            var expectedJson = JsonConvert.SerializeObject(expectedGameState);
            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent, Is.EqualTo(expectedJson));
        }

        private Task<HttpResponseMessage> PostMoveRequest(int cellId) => _httpClient.PostAsync($"game/move/{cellId}", null);

        private Task<HttpResponseMessage> PostNewGameRequest() => _httpClient.PostAsync("game/new", null);
    }
}