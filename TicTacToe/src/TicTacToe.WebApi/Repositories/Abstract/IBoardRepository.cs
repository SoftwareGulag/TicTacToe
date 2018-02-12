using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Repositories.Abstract
{
    public interface IBoardRepository
    {
        void Set(Board board);
        Board Get();
    }
}