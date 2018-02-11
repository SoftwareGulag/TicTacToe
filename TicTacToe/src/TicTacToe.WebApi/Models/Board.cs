using System.Collections.Generic;
using System.Linq;
using TicTacToe.WebApi.Exceptions;

namespace TicTacToe.WebApi.Models
{
    public class Board
    {
        private readonly CellState[] _cells;
        private readonly Dictionary<CellState, string> _cellStateMap;

        public Board()
        {
            _cells = new CellState[9];
            _cellStateMap = new Dictionary<CellState, string>
            {
                {CellState.O, "o"},
                {CellState.X, "x"},
                {CellState.Empty, "_"}
            };
        }

        public string Serialize()
        {
            var mappedCells = _cells.Select(MapToString);

            return $"{{[{string.Join(",", mappedCells)}]}}";
        }

        private string MapToString(CellState cellState) => _cellStateMap[cellState];

        public void MakeMove(uint i)
        {
            if (_cells[i] != CellState.Empty)
            {
                throw new InvalidMoveException();
            }

            _cells[i] = GetNextCellState();
        }

        private CellState GetNextCellState() => IsTicTheNextMove() ? CellState.O : CellState.X;

        private bool IsTicTheNextMove() => _cells.Count(c => c != CellState.Empty) % 2 == 0;
    }
}