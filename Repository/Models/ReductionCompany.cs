using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class ReductionCompany : IBaseModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Paid { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
    }
}
