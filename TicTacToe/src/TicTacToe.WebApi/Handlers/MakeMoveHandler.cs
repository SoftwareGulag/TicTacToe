using MediatR;
using TicTacToe.WebApi.Boundary;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Repositories.Abstract;
using TicTacToe.WebApi.Requests;
using TicTacToe.WebApi.Services;

namespace TicTacToe.WebApi.Handlers
{
    public class MakeMoveHandler : RequestHandler<MakeMoveRequest, GameStateResponse>
    {
        private readonly IUmpire _umpire;
        private readonly IBoardRepository _boardRepository;

        public MakeMoveHandler(IUmpire umpire, IBoardRepository boardRepository)
        {
            _umpire = umpire;
            _boardRepository = boardRepository;
        }

        protected override GameStateResponse HandleCore(MakeMoveRequest message)
        {
            var board = _boardRepository.Get();
            board.MakeMove(message.CellId);
            var outcome = _umpire.DecideOutcome(board);

            return new GameStateResponse(board.Print(), outcome);
        }
    }
}