using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.WebApi.Controllers
{
    public class GameController : Controller
    {
        [HttpPost, Route("game/new")]
        public async Task<IActionResult> CreateNewGame()
        {
            return Ok("{[_,_,_,_,_,_,_,_,_]}");
        }
    }
}