using Business_Logic_Layer.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IGameService : ICrud<GameModel>
    {
        Task<IEnumerable<GameModel>> GetByFilterAsync(SearchModel searchModel);
        Task AddGenreToGameAsync(int gameId, int genreId);
        Task RemoveGenreFromGameAsync(int gameId, int genreId);
        Task AddGenreAsync(GenreModel genreModel);
        Task RemoveGenreAsync(int genreId);
        Task<GenreModel> UpdateGenreAsync(GenreModel genreModel);
        Task AddPEGIRatingAsync(PEGIRatingModel pegiModel);
        Task RemovePEGIRatingAsync(int pegiId);
        Task<IEnumerable<PEGIRatingModel>> GetAllPEGIRatingAsync();
        Task<IEnumerable<GenreModel>> GetAllGenresAsync();
        Task<PEGIRatingModel> GetPEGIRatingByIdAsync(int pegiId);
        Task<PEGIRatingModel> UpdatePEGIRatingAsync(PEGIRatingModel pegiModel);
        Task<GenreModel> GetGenreByIdAsync(int id);
    }
}
