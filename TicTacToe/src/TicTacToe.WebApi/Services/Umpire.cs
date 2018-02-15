using System.Collections.Generic;
using System.Linq;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Services
{
    public class Umpire : IUmpire
    {
        public GameOutcome DecideOutcome(Board board)
        {
            if (!board.Cells.Contains(CellState.Empty))
            {
                return GameOutcome.Draw;
            }

            if (EvaluateRowVictoryCondition(board.Cells, CellState.O))
            {
                return GameOutcome.OHasWon;
            }

            if (EvaluateRowVictoryCondition(board.Cells, CellState.X))
            {
                return GameOutcome.XHasWon;
            }

            if (EvaluateColumnVictoryCondition(board.Cells, CellState.O))
            {
                return GameOutcome.OHasWon;
            }

            if (EvaluateColumnVictoryCondition(board.Cells, CellState.X))
            {
                return GameOutcome.XHasWon;
            }

            if (EvaluateDiagonalRowVictoryCondition(board.Cells, CellState.O))
            {
                return GameOutcome.OHasWon;
            }

            if (EvaluateDiagonalRowVictoryCondition(board.Cells, CellState.X))
            {
                return GameOutcome.XHasWon;
            }

            return GameOutcome.OpenOutcome;
        }

        private static bool EvaluateColumnVictoryCondition(CellState[] cells, CellState cellState)
        {
            var transposedCells = Transpose(cells);
            return EvaluateRowVictoryCondition(transposedCells, cellState);
        }

        private static CellState[] Transpose(CellState[] cells)
        {
            var transposedCells = new CellState[9];

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    transposedCells[j + i * 3] = cells[j * 3 + i];

            return transposedCells;
        }

        private static bool EvaluateRowVictoryCondition(CellState[] cells, CellState cellState)
        {
            var rowEvaluationResults = new List<bool>();
            for (var rowNumber = 0; rowNumber < 7; rowNumber += 3)
            {
                var row = TakeRow(cells, rowNumber);
                var result = EvaluateRow(row, cellState);
                rowEvaluationResults.Add(result);
            }

            return rowEvaluationResults.Any(evaluationResult => evaluationResult);
        }

        private static IEnumerable<CellState> TakeRow(IEnumerable<CellState> cells, int rowNumber) => cells.Skip(rowNumber).Take(3);

        private static bool EvaluateDiagonalRowVictoryCondition(CellState[] cells, CellState cellState)
        {
            var rowEvaluationResults = new List<bool>();
            
            for(int startIndex = 0, offset = 4 ; offset > 1; offset = offset / 2, startIndex +=2)
            {
                var diagonal = new CellState[3];

                for (var j = 0; j < 3; j++)
                {
                    diagonal[j] = cells[startIndex + j * offset];
                }
                var result = EvaluateRow(diagonal, cellState);
                rowEvaluationResults.Add(result);
            }

            return rowEvaluationResults.Any(evaluationResult => evaluationResult);
        }

        private static bool EvaluateRow(IEnumerable<CellState> row, CellState cellState) => row.All(cs => cs == cellState);
    }
}