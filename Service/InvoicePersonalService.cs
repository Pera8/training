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
    public class InvoicePersonalService
    {
        static InvoicePersonalService() => MapperConfig.RegisterInvoicePersonalMapping();

        private readonly IRepository<InvoicePersonal> repositoryInvoicePersonal;
        private readonly IRepository<Personal> repositoryPersonal;

        public InvoicePersonalService(IRepository<InvoicePersonal> repositoryInvoicePersonal, IRepository<Personal> repositoryPersonal)
        {
            this.repositoryInvoicePersonal = repositoryInvoicePersonal;
            this.repositoryPersonal = repositoryPersonal;
        }
        public async Task<InvoicePersonal> AddAsync(InvoicePersonalDTO model)
        {
            if (model == null)
            {
                throw new Exception("InvoicePersonal can not be null");
            }
            var personal = await repositoryPersonal.GetAsyncById(model.PersonalID);
            var invoicePersonal = TypeAdapter.Adapt<InvoicePersonalDTO, InvoicePersonal>(model);
            invoicePersonal.Personal = personal;
            invoicePersonal.DateTime = DateTime.Now;
            invoicePersonal.Personal.SumPersonal += model.Debt;

            return await repositoryInvoicePersonal.AddAsync(invoicePersonal);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryInvoicePersonal.DeleteAsync(id);
        }

        public async Task<IQueryable<InvoicePersonal>> GetAllAsync()
        {
            return await repositoryInvoicePersonal.GetAllAsync(x =>x.Include(y=>y.Personal));
        }

        public async Task<InvoicePersonal> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryInvoicePersonal.GetAsyncById(id);
        }
    }
}
