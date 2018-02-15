using System.Collections.Generic;
using System.Linq;
using TicTacToe.WebApi.Exceptions;

namespace TicTacToe.WebApi.Models
{
    public class Board
    {
        public CellState[] Cells { get; }
        private readonly Dictionary<CellState, string> _cellStateMap;

        public Board()
        {
            Cells = new CellState[9];
            _cellStateMap = new Dictionary<CellState, string>
            {
                {CellState.O, "\"o\""},
                {CellState.X, "\"x\""},
                {CellState.Empty, "\"_\""}
            };
        }

        public string Print()
        {
            var mappedCells = Cells.Select(MapToString);

            return $"{{\"state\": [{string.Join(",", mappedCells)}]}}";
        }

        private string MapToString(CellState cellState) => _cellStateMap[cellState];

        public void MakeMove(int i)
        {
            if (i < 0 || i > 8 ) throw new OutsideOfBoardRangeException();
            if (Cells[i] != CellState.Empty) throw new InvalidMoveException();

            Cells[i] = GetNextCellState();
        }

        private CellState GetNextCellState() => IsTicTheNextMove() ? CellState.O : CellState.X;

        private bool IsTicTheNextMove() => Cells.Count(c => c != CellState.Empty) % 2 == 0;
    }
}