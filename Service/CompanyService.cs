using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompanyService
    {
        private readonly IRepository<Company> repositoryCompany;
        private readonly ICompanyRepository companyRepository;
        public CompanyService(IRepository<Company> repositoryCompany, ICompanyRepository companyRepository)
        {
            this.repositoryCompany = repositoryCompany;
            this.companyRepository = companyRepository;
        }

        public async Task<Company> AddAsync(Company model)
        {
            if (model == null)
            {
                throw new Exception("Company can not e null");
            }
            return await repositoryCompany.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("Company with this Id does not exist");
            }
            await repositoryCompany.DeleteAsync(id);
        }

        public async Task<IQueryable<Company>> GetAllAsync()
        {
            return await repositoryCompany.GetAllAsync(source => source
                .Include(x => x.InvoiceCompaniesList)
                .Include(x => x.ReductionCompanies)
            );
        }

        public async Task<Company> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Company with this Id does not exist");
            }
            return await repositoryCompany.GetAsyncById(id);
        }

        public async Task<IEnumerable<Company>> FilterCompany(string filter)
        {
            return await companyRepository.FilterCompanyName(filter);
        }
    }
}
