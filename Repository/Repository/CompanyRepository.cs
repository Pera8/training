using Repository.Models;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly AppDbContext appDbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Company>> FilterCompanyName(string filter)
        {
            var company =  appDbContext.Companies.Where(c => c.Name.Contains(filter));

            if (!string.IsNullOrWhiteSpace(filter))
            {
                company = company.Where(c => c.Name.ToLower().Contains(filter.ToLower()));
            }


            return company;
        }
    }
}
