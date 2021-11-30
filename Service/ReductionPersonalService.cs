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
    public class ReductionPersonalService
    {
        static ReductionPersonalService() => MapperConfig.RegisterReductionPersonalMapping();

        private readonly IRepository<ReductionPersonal> repositoryReductionPersonal;
        private readonly IRepository<Personal> repositoryPersonal;
        public ReductionPersonalService(IRepository<ReductionPersonal> repositoryReductionPersonal , IRepository<Personal> repositoryPersonal)
        {
            this.repositoryReductionPersonal = repositoryReductionPersonal;
            this.repositoryPersonal = repositoryPersonal;
        }
        public async Task<ReductionPersonal> AddAsync(ReductionPersonalDTO model)
        {
            if (model == null)
            {
                throw new Exception("College can not be null");
            }
            var personal = await repositoryPersonal.GetAsyncById(model.PersonalID);
            var reductionPersonal = TypeAdapter.Adapt<ReductionPersonalDTO, ReductionPersonal>(model);
            reductionPersonal.Personal = personal;
            reductionPersonal.DateTime = DateTime.Now;
            reductionPersonal.Personal.SumPersonal -= model.Paid;

            return await repositoryReductionPersonal.AddAsync(reductionPersonal);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryReductionPersonal.DeleteAsync(id);
        }

        public async Task<IQueryable<ReductionPersonal>> GetAllAsync()
        {
            return await repositoryReductionPersonal.GetAllAsync();
        }

        public async Task<ReductionPersonal> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryReductionPersonal.GetAsyncById(id);
        }
    }
}
