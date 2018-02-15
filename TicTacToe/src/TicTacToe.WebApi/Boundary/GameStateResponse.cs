using Newtonsoft.Json;
using TicTacToe.WebApi.Models;

namespace TicTacToe.WebApi.Boundary
{
    public class GameStateResponse
    {
        [JsonProperty("board")]
        public string Board { get; }

        [JsonProperty("hasOWonGame")]
        public bool HasOWonGame { get; }

        [JsonProperty("hasXWonGame")]
        public bool HasXWonGame { get; }

        [JsonProperty("openOutcome")]
        public bool OpenOutcome { get; set; }

        [JsonProperty("draw")]
        public bool Draw { get;}

        public GameStateResponse(string board) => Board = board;


        public GameStateResponse(string board, GameOutcome gameOutcome)
        {
            Board = board;
            OpenOutcome = gameOutcome == GameOutcome.OpenOutcome;
            HasOWonGame = gameOutcome == GameOutcome.OHasWon;
            HasXWonGame = gameOutcome == GameOutcome.XHasWon;
            Draw = gameOutcome == GameOutcome.Draw;
        }
    }
}