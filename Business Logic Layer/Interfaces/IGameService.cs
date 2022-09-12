using Business_Logic_Layer.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    internal interface IGameService : ICrud<GameModel>
    {
        Task<IEnumerable<GameModel>> GetByFilterAsync(SearchModel searchModel);
        Task AddGenreToGame(int gameId, int genreId);
        Task AddGenreAsync(GenreModel genreModel);
        Task RemoveGenreAsync(int genreId);
        Task UpdateGenreAsync(GenreModel genreModel);
        Task AddPEGIRatingAsync(PEGIRatingModel pegiModel);
        Task RemovePEGIRatingAsync(PEGIRatingModel pegiModel);
        Task GetAllPEGIRatingAsync();
        Task GetPEGIRatingByIdAsync(int pegiId);
        Task UpdatePEGIRatingAsync(PEGIRatingModel pegiModel);
    }
}
