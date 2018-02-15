using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Services;

namespace TicTacToe.WebApi.Tests
{
    [TestFixture]
    public class UmpireTest
    {
        [Test]
        public void DecideOutcome_GivenEmptyBoard_ReturnsOpenOutcome()
        {
            var umpire = new Umpire();
            var result = umpire.DecideOutcome(new Board());
            Assert.That(result, Is.EqualTo(GameOutcome.OpenOutcome));
        }

        [Test]
        public void DecideOutcome_GivenFilledBoard_WhenNoOneHasWon_ReturnsDraw()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new []{0, 1, 2, 4, 3, 5, 7, 6, 8});
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.Draw));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_o_FilledFirstRow_ReturnsOHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 0, 4, 1, 3, 2});
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.OHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_x_FilledFirstRow_ReturnsXHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 4, 0, 3, 1, 7, 2});
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.XHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_o_FilledSecondRow_ReturnsOHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 3, 0, 4, 6, 5});
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.OHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_x_FilledThirdRow_ReturnsXHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 3, 6, 4, 7, 1, 8 });
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.XHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_o_FilledFirstColumn_ReturnsOHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 0, 1, 3, 2, 6 });
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.OHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_x_FilledSecondColumn_ReturnsXHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 0, 1, 2, 4, 5, 7 });
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.XHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_o_FilledDiagonalRow_ReturnsOHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 0, 1, 4, 2, 8 });
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.OHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_x_FilledDiagonalRow_ReturnsXHasWon()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 0, 2, 1, 4, 8, 6 });
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.XHasWon));
        }

        [Test]
        public void DecideOutcome_WhenPlayer_o_MadMove_4_ReturnsOpenOutcome()
        {
            var umpire = new Umpire();
            var board = SimulateGame(new[] { 4});
            var result = umpire.DecideOutcome(board);
            Assert.That(result, Is.EqualTo(GameOutcome.OpenOutcome));
        }

        private static Board SimulateGame(IEnumerable<int> listOfMoves)
        {
            var board = new Board();

            foreach (var move in listOfMoves)
            {
                board.MakeMove(move);                
            }

            return board;
        }
    }
}