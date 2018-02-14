using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TicTacToe.WebApi.Exceptions;
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
            var gameStateResponse = await _mediator.Send(new CreateBoardRequest());
            return Ok(gameStateResponse);
        }

        [InvalidMoveExceptionFilter]
        [HttpPost, Route("game/move/{cellId}")]
        public async Task<IActionResult> MakeMove(int cellId)
        {
            var gameStateResponse = await _mediator.Send(new MakeMoveRequest(cellId));
            return Ok(gameStateResponse);
        }
    }
}