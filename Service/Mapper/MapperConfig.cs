using Mapster;
using Repository.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public static class MapperConfig
    {
        public static void RegisterInvoiceCompanyMapping()
        {
            TypeAdapterConfig<InvoiceCompany, InvoiceCompanyDTO>.NewConfig()
                .Map(des => des.CompanyId,
                src => src.Company.Id,
                src => src.Company != null);

            TypeAdapterConfig<InvoiceCompanyDTO, InvoiceCompany>.NewConfig();
        }

        public static void RegisterReductionCompanyMapping()
        {
            TypeAdapterConfig<ReductionCompany, ReductionCompanyDTO>.NewConfig()
                .Map(des => des.CompanyId,
                src => src.Company.Id,
                src => src.Company != null);

            TypeAdapterConfig<ReductionCompanyDTO, ReductionCompany>.NewConfig();
        }

        public static void RegisterInvoicePersonalMapping()
        {
            TypeAdapterConfig<InvoicePersonal, InvoicePersonalDTO>.NewConfig()
                .Map(des => des.PersonalID,
                src => src.Personal.Id,
                src => src.Personal != null);

            TypeAdapterConfig<InvoicePersonalDTO, InvoicePersonal>.NewConfig();
        }

        public static void RegisterReductionPersonalMapping()
        {
            TypeAdapterConfig<ReductionPersonal, ReductionPersonalDTO>.NewConfig()
                .Map(des => des.PersonalID,
                src => src.Personal.Id,
                src => src.Personal != null);

            TypeAdapterConfig<ReductionPersonalDTO, ReductionPersonal>.NewConfig();
        }
    }
}
