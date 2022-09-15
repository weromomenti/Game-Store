using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;

namespace Game_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetAll()
        {
            var games = await gameService.GetAllAsync();
            return new OkObjectResult(games);
        }
        [HttpGet("pegi")]
        public async Task<ActionResult<IEnumerable<PEGIRatingModel>>> GetAllPEGI()
        {
            var pegiRatings = await gameService.GetAllPEGIRatingAsync();
            return new OkObjectResult(pegiRatings);
        }
        [HttpGet("pegi")]
        public async Task<ActionResult<IEnumerable<GenreModel>>> GetAllGenres()
        {
            var genres = await gameService.GetAllGenresAsync();
            return new OkObjectResult(genres);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetByIdAsync(int id)
        {
            var game = await gameService.GetByIdAsync(id);
            return new OkObjectResult(game);
        }
        [HttpPost]
        public async Task<ActionResult> AddGameAsync([FromBody] GameModel model)
        {
            await gameService.AddAsync(model);
            return new OkResult();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGameAsync(int id, [FromBody] GameModel gameModel)
        {
            await gameService.UpdateAsync(gameModel);
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<GameModel>>> DeleteGameAsync(int id)
        {
            await gameService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
