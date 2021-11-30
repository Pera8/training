using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PersonalService
    {
        private readonly IRepository<Personal> repositoryPersonal;
        private readonly IPersonalRepository personalRepository;

        public PersonalService(IRepository<Personal> repositoryPersonal, IPersonalRepository personalRepository)
        {
            this.repositoryPersonal = repositoryPersonal;
            this.personalRepository = personalRepository;
        }
        public async Task<Personal> AddAsync(Personal model)
        {
            if (model == null)
            {
                throw new Exception("Personal can not be null");
            }

            return await repositoryPersonal.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("Personal with this Id does not exist");
            }
            await repositoryPersonal.DeleteAsync(id);
        }

        public async Task<IQueryable<Personal>> GetAllAsync()
        {
            return await repositoryPersonal.GetAllAsync(s=>s
                .Include(x =>x.InvoicePersonalsList)
                .Include(f => f.ReductionPersonals));
        }

        public async Task<Personal> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Personal with this Id does not exist");
            }
            return await repositoryPersonal.GetAsyncById(id);
        }

        public async Task<IEnumerable<Personal>> FilterCompany(string filter)
        {
            return await personalRepository.FilterCompanyName(filter);
        }
    }
}
