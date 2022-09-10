using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllWithDetailsAsync();
        Task<Genre> GetByIdWithDetailsAsync();
    }
}
