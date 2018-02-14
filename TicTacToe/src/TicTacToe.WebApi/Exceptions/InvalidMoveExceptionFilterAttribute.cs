using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TicTacToe.WebApi.Exceptions
{
    public class InvalidMoveExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case InvalidMoveException _:
                    context.Result = new BadRequestResult();
                    break;
                case OutsideOfBoardRangeException _:
                    context.Result = new BadRequestResult();
                    break;
            }
        }
    }
}