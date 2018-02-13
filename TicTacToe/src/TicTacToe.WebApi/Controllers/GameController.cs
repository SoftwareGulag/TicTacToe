using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.WebApi.Requests;

namespace TicTacToe.WebApi.Controllers
{
    public class GameController : Controller
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("game/new")]
        public async Task<IActionResult> CreateNewGame()
        {
            var board = await _mediator.Send(new CreateBoardRequest());
            return Ok(board);
        }

        [HttpPost, Route("game/move/{cellId}")]
        public async Task<IActionResult> MakeMove(int cellId)
        {
            var board = await _mediator.Send(new MakeMoveRequest(cellId));
            return Ok(board);
        }
    }
}