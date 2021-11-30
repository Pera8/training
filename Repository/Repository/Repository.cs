using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repository.Interface;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class, IBaseModel
    {
        private readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<TModel> AddAsync(TModel model)
        {
            await appDbContext.AddAsync(model);
            await appDbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await appDbContext.Set<TModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
            appDbContext.Remove(result);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<TModel>> GetAllAsync(Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null)
        {
            IQueryable<TModel> query = appDbContext.Set<TModel>();
            if (include != null)
            {
                query = include(query);
            }
            return query;
        }

        public async Task<TModel> GetAsyncById(int id)
        {
            return await appDbContext.Set<TModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
           
        }

        public IEnumerable<TModel> Filter(Func<TModel, bool> predicate)
        {
            return  appDbContext.Set<TModel>().Where(predicate);
        }
    }
}
