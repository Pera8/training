using Repository.Models;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly AppDbContext appDbContext;

        public PersonalRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Personal>> FilterCompanyName(string filter)
        {
            var personal = appDbContext.Personals.Where(c => c.Name.Contains(filter));

            if (!string.IsNullOrWhiteSpace(filter))
            {
                personal = personal.Where(c => c.Name.ToLower().Contains(filter.ToLower()));
            }


            return personal;
        }
    }
}
