using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IRepository<TModel> where TModel: class, IBaseModel
    {
        Task<TModel> AddAsync(TModel model);
        Task<IQueryable<TModel>> GetAllAsync(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null);
        Task<TModel> GetAsyncById(int id);
        Task DeleteAsync(int id);
        IEnumerable<TModel> Filter(Func<TModel, bool> predicate);
    }
}
