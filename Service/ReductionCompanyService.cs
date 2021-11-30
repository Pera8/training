using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Mapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReductionCompanyService
    {
        static ReductionCompanyService() => MapperConfig.RegisterReductionCompanyMapping();

        private readonly IRepository<ReductionCompany> repositoryReductionCompany;
        private readonly IRepository<Company> repositoryCompany;

        public ReductionCompanyService(IRepository<ReductionCompany> repositoryReductionCompany, IRepository<Company> repositoryCompany)
        {
            this.repositoryReductionCompany = repositoryReductionCompany;
            this.repositoryCompany = repositoryCompany;
        }
        public async Task<ReductionCompany> AddAsync(ReductionCompanyDTO model)
        {
            if (model == null)
            {
                throw new Exception("ReductionCompany can not be null");
            }
            var company = await repositoryCompany.GetAsyncById(model.CompanyId);
            var reductionCompany = TypeAdapter.Adapt<ReductionCompanyDTO, ReductionCompany>(model);
            reductionCompany.DateTime = DateTime.Now;
            reductionCompany.Company = company;
            reductionCompany.Company.Account -= model.Paid;

            return await repositoryReductionCompany.AddAsync(reductionCompany);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryReductionCompany.DeleteAsync(id);
        }

        public async Task<IQueryable<ReductionCompany>> GetAllAsync()
        {
            return await repositoryReductionCompany.GetAllAsync(x => x.Include(y => y.Company));
        }

        public async Task<ReductionCompany> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryReductionCompany.GetAsyncById(id);
        }
    }
}
