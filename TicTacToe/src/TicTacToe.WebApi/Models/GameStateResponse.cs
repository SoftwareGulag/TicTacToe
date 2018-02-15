﻿using Newtonsoft.Json;

namespace TicTacToe.WebApi.Models
{
    public class GameStateResponse
    {
        [JsonProperty("board")]
        public string Board { get; }

        [JsonProperty("hasOWonGame")]
        public bool HasOWonGame { get; }

        [JsonProperty("hasXWonGame")]
        public bool HasXWonGame { get; }

        public GameStateResponse(string board) => Board = board;

        public GameStateResponse(string board, GameOutcome gameOutcome)
        {
            Board = board;
            HasOWonGame = gameOutcome == GameOutcome.OHasWon;
            HasXWonGame = gameOutcome == GameOutcome.XHasWon;
        }
    }
}