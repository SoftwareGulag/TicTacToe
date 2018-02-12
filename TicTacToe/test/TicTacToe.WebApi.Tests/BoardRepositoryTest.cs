using NUnit.Framework;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Repositories;

namespace TicTacToe.WebApi.Tests
{
    [TestFixture]
    public class BoardRepositoryTest
    {
        [Test]
        public void GivenBoard_WhenSetSavesBoard_GetReturnsTheSameBoard()
        {
            var board = new Board();
            var boardRepository = new BoardRepository();

            boardRepository.Set(board);
            var result = boardRepository.Get();

            Assert.That(result.GetHashCode(), Is.EqualTo(board.GetHashCode()));
        }
    }
}