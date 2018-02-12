using MediatR;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Repositories.Abstract;
using TicTacToe.WebApi.Requests;

namespace TicTacToe.WebApi.Handlers
{
    public class MakeMoveHandler : RequestHandler<MakeMoveRequest, Board>
    {
        private readonly IBoardRepository _boardRepository;

        public MakeMoveHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        protected override Board HandleCore(MakeMoveRequest message)
        {
            var board = _boardRepository.Get();
            board.MakeMove(message.CellId);

            return board;
        }
    }
}