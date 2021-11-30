using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class InvoiceCompanyDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Debt { get; set; }
        public int CompanyId { get; set; }
    }
}
