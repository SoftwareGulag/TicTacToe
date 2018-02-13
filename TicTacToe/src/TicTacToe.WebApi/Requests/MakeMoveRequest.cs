using MediatR;

namespace TicTacToe.WebApi.Requests
{
    public class MakeMoveRequest : IRequest<string>
    {
        public int CellId { get; }

        public MakeMoveRequest(int cellId)
        {
            CellId = cellId;
        }
    }
}