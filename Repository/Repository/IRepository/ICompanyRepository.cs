﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> FilterCompanyName(string filter);
    }
}
