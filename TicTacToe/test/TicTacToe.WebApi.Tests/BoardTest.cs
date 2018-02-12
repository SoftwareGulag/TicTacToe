using NUnit.Framework;
using TicTacToe.WebApi.Exceptions;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Tests
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void Serialize_GivenEmptyBoard_ReturnsArrayOfDash()
        {
            var board = new Board();
            Assert.That(board.Print(), Is.EqualTo("{[_,_,_,_,_,_,_,_,_]}"));
        }

        [Test]
        public void MakeMove_GivenCellNumber0_ReturnsArrayWith_o_at_0()
        {
            var board = new Board();
            board.MakeMove(0);
            Assert.That(board.Print(), Is.EqualTo("{[o,_,_,_,_,_,_,_,_]}"));
        }

        [Test]
        public void MakeMove_WhenSecondMoveIsGivenAlreadyTakenCellNumber_ThrowsInvalidMoveException()
        {
            var board = new Board();
            board.MakeMove(0);
            Assert.That(() => board.MakeMove(0), Throws.InstanceOf<InvalidMoveException>());
        }

        [Test]
        public void MakeMove_GivenCellNumber1_ReturnsArrayWith_o_at_0()
        {
            var board = new Board();
            board.MakeMove(1);
            Assert.That(board.Print(), Is.EqualTo("{[_,o,_,_,_,_,_,_,_]}"));
        }

        [Test]
        public void MakeMove_SecondMove_ReturnsArrayWith_o_and_x()
        {
            var board = new Board();
            board.MakeMove(1);
            board.MakeMove(0);
            Assert.That(board.Print(), Is.EqualTo("{[x,o,_,_,_,_,_,_,_]}"));
        }
    }
}