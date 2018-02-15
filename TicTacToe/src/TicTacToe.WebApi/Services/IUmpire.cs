using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Services
{
    public interface IUmpire
    {
        GameOutcome DecideOutcome(Board board);
    }
}