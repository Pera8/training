﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class ReductionPersonalDTO
    {
        public int Id { get; set; }
        public double Paid { get; set; }
        public string Description { get; set; }
        public int PersonalID { get; set; }
    }
}
