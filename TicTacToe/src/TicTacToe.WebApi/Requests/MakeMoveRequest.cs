using MediatR;
using TicTacToe.WebApi.Boundary;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Requests
{
    public class MakeMoveRequest : IRequest<GameStateResponse>
    {
        public int CellId { get; }

        public MakeMoveRequest(int cellId)
        {
            CellId = cellId;
        }
    }
}