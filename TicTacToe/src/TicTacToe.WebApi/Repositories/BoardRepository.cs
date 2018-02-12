using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Repositories.Abstract;

namespace TicTacToe.WebApi.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private Board _board;

        public void Set(Board board)
        {
            _board = board;
        }

        public Board Get()
        {
            return _board;
        }
    }
}