using Business_Logic_Layer.Models;
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
        Task AddGenreAsync(GenreModel genreModel);
        Task RemoveGenreAsync(int genreId);
        Task UpdateGenreAsync(GenreModel genreModel);
    }
}
