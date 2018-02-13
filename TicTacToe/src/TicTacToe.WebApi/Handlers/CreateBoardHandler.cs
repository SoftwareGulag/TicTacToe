using MediatR;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Repositories.Abstract;
using TicTacToe.WebApi.Requests;

namespace TicTacToe.WebApi.Handlers
{
    public class CreateBoardHandler : RequestHandler<CreateBoardRequest, string>
    {
        private readonly IBoardRepository _boardRepository;

        public CreateBoardHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        protected override string HandleCore(CreateBoardRequest request)
        {
            var board = new Board();
            _boardRepository.Set(board);
            return board.Print();
        }
    }
}