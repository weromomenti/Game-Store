using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetAllGames([FromQuery] SearchModel searchModel)
        {
            var games = await gameService.GetByFilterAsync(searchModel);
            return new OkObjectResult(games);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpGet("pegi")]
        public async Task<ActionResult<IEnumerable<PEGIRatingModel>>> GetAllPEGI()
        {
            var pegiRatings = await gameService.GetAllPEGIRatingAsync();
            return new OkObjectResult(pegiRatings);
        }
        [AllowAnonymous]
        [HttpGet("genres")]
        public async Task<ActionResult<IEnumerable<GenreModel>>> GetAllGenres()
        {
            var genres = await gameService.GetAllGenresAsync();
            return new OkObjectResult(genres);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetByIdAsync(int id)
        {
            var game = await gameService.GetByIdAsync(id);
            return new OkObjectResult(game);
        }
        [Authorize(Policy = "StandardRights")]
        [HttpGet("genre/{id}")]
        public async Task<ActionResult<GenreModel>> GetGenreByIdAsync(int id)
        {
            var genre = await gameService.GetGenreByIdAsync(id);
            return new OkObjectResult(genre);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPost]
        public async Task<ActionResult> AddGameAsync([FromBody] GameModel model)
        {
            await gameService.AddAsync(model);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPost("genres")]
        public async Task<ActionResult> AddGenreAsync([FromBody] GenreModel genre)
        {
            await gameService.AddGenreAsync(genre);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPost("pegi")]
        public async Task<ActionResult> AddPEGIAsync([FromBody] PEGIRatingModel pegi)
        {
            await gameService.AddPEGIRatingAsync(pegi);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGameAsync(int id, [FromBody] GameModel gameModel)
        {
            await gameService.UpdateAsync(gameModel);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPut("genre/{id}")]
        public async Task<ActionResult> UpdateGenreAsync(int id, [FromBody] GenreModel genreModel)
        {
            await gameService.UpdateGenreAsync(genreModel);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPut("pegi/{id}")]
        public async Task<ActionResult> UpdatePegiAsync(int id, [FromBody] PEGIRatingModel pegi)
        {
            await gameService.UpdatePEGIRatingAsync(pegi);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameAsync(int id)
        {
            await gameService.DeleteAsync(id);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpDelete("genre/{id}")]
        public async Task<ActionResult> DeleteGenreAsync(int id)
        {
            await gameService.RemoveGenreAsync(id);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpDelete("pegi/{id}")]
        public async Task<ActionResult> DeletePegiAsync(int id)
        {
            await gameService.RemovePEGIRatingAsync(id);
            return new OkResult();
        }
    }
}
