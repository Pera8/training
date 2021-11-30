using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Personal : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public double SumPersonal { get; set; }
        public string BankAccount { get; set; }
        public List<InvoicePersonal> InvoicePersonalsList { get; set; }
        public List<ReductionPersonal> ReductionPersonals { get; set; }
    }
}
