using MediatR;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Requests
{
    public class MakeMoveRequest : IRequest<Board>
    {
        public int CellId { get; }

        public MakeMoveRequest(int cellId)
        {
            CellId = cellId;
        }
    }
}