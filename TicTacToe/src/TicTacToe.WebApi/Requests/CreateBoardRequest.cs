using MediatR;
using TicTacToe.WebApi.Boundary;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Requests
{
    public class CreateBoardRequest : IRequest<GameStateResponse>
    {
        
    }
}