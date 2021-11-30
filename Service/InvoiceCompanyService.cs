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
    public class InvoiceCompanyService
    {
        static InvoiceCompanyService() => MapperConfig.RegisterInvoiceCompanyMapping();

        private readonly IRepository<InvoiceCompany> repositoryInvoiceCompany;
        private readonly IRepository<Company> repositoryCompany;

        public InvoiceCompanyService(IRepository<InvoiceCompany> repositoryInvoiceCompany, IRepository<Company> repositoryCompany)
        {
            this.repositoryInvoiceCompany = repositoryInvoiceCompany;
            this.repositoryCompany = repositoryCompany;
        }

        public async Task<InvoiceCompany> AddAsyncInvoice(InvoiceCompanyDTO model)
        {
            if (model == null)
            {
                throw new Exception("InvoiceCompany can not be null");
            }

            var company = await repositoryCompany.GetAsyncById(model.CompanyId);

            var invoiceCompany = TypeAdapter.Adapt<InvoiceCompanyDTO, InvoiceCompany>(model);
            invoiceCompany.DateTime =  DateTime.Now;
            invoiceCompany.Company = company;
            invoiceCompany.Company.Account += model.Debt;
            return await repositoryInvoiceCompany.AddAsync(invoiceCompany); 
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryInvoiceCompany.DeleteAsync(id);
        }

        public async Task<IQueryable<InvoiceCompany>> GetAllAsync()
        {
            return await repositoryInvoiceCompany.GetAllAsync(x => x.Include(y => y.Company));
        }

        public async Task<InvoiceCompany> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryInvoiceCompany.GetAsyncById(id);
            
        }

       
    }
}
