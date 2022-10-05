using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Game_Store.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetAllGames([FromQuery] SearchModel searchModel)
        {
            var games = await gameService.GetByFilterAsync(searchModel);
            return new OkObjectResult(games);
        }
        [HttpGet("pegi")]
        public async Task<ActionResult<IEnumerable<PEGIRatingModel>>> GetAllPEGI()
        {
            var pegiRatings = await gameService.GetAllPEGIRatingAsync();
            return new OkObjectResult(pegiRatings);
        }
        [HttpGet("genres")]
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
        [HttpGet("genre/{id}")]
        public async Task<ActionResult<GenreModel>> GetGenreByIdAsync(int id)
        {
            var genre = await gameService.GetGenreByIdAsync(id);
            return new OkObjectResult(genre);
        }
        [HttpPost]
        public async Task<ActionResult> AddGameAsync([FromBody] GameModel model)
        {
            await gameService.AddAsync(model);
            return new OkResult();
        }
        [HttpPost("genres")]
        public async Task<ActionResult> AddGenreAsync([FromBody] GenreModel genre)
        {
            await gameService.AddGenreAsync(genre);
            return new OkResult();
        }
        [HttpPost("pegi")]
        public async Task<ActionResult> AddPEGIAsync([FromBody] PEGIRatingModel pegi)
        {
            await gameService.AddPEGIRatingAsync(pegi);
            return new OkResult();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGameAsync(int id, [FromBody] GameModel gameModel)
        {
            await gameService.UpdateAsync(gameModel);
            return new OkResult();
        }
        [HttpPut("genre/{id}")]
        public async Task<ActionResult> UpdateGenreAsync(int id, [FromBody] GenreModel genreModel)
        {
            await gameService.UpdateGenreAsync(genreModel);
            return new OkResult();
        }
        [HttpPut("pegi/{id}")]
        public async Task<ActionResult> UpdatePegiAsync(int id, [FromBody] PEGIRatingModel pegi)
        {
            await gameService.UpdatePEGIRatingAsync(pegi);
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameAsync(int id)
        {
            await gameService.DeleteAsync(id);
            return new OkResult();
        }
        [HttpDelete("genre/{id}")]
        public async Task<ActionResult> DeleteGenreAsync(int id)
        {
            await gameService.RemoveGenreAsync(id);
            return new OkResult();
        }
        [HttpDelete("pegi/{id}")]
        public async Task<ActionResult> DeletePegiAsync(int id)
        {
            await gameService.RemovePEGIRatingAsync(id);
            return new OkResult();
        }
    }
}
