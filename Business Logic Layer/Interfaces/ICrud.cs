using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    internal interface ICrud<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task AddAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(int modelId);
    }
}
