using TicTacToe.WebApi.Exceptions;

namespace TicTacToe.WebApi.Models
{
    public class Board
    {
        private readonly CellState[] _cells;
        private CellState _nextMove;

        public Board()
        {
            _nextMove = CellState.O;
            _cells = new CellState[9];
        }

        public string Serialize()
        {
            var cellString = new string [9];

            for (var i = 0; i < _cells.Length; i++)
            {
                if (_cells[i] == CellState.O)
                {
                    cellString[i] = "o";
                }
                else if (_cells[i] == CellState.X)
                {
                    cellString[i] = "x";
                }
                else
                {
                    cellString[i] = "_";
                }
            }
            
            return $"{{[{string.Join(",", cellString)}]}}";
        }

        public void MakeMove(uint i)
        {
            if (_cells[i] != CellState.Empty)
            {
                throw new InvalidMoveException();
            }

            if (_nextMove == CellState.O)
            {
                _cells[i] = CellState.O;
                _nextMove = CellState.X;
            }
            else
            {
                _cells[i] = CellState.X;
                _nextMove = CellState.O;
            }
        }
    }
}