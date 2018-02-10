using MediatR;
using TicTacToe.WebApi.Controllers;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Requests;

namespace TicTacToe.WebApi.Handlers
{
    public class CreateBoardHandler : RequestHandler<CreateBoardRequest, Board>
    {
        protected override Board HandleCore(CreateBoardRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}