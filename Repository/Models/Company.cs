using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Company : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Pib { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public double Account { get; set; }
        public string BankAccount { get; set; }
        public List<InvoiceCompany> InvoiceCompaniesList { get; set; }
        public List<ReductionCompany> ReductionCompanies { get; set; }
    }
}
