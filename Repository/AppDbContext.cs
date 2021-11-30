using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<InvoiceCompany> InvoiceCompanies { get; set; }
        public DbSet<InvoicePersonal> InvoicePersonals { get; set; }
        public DbSet<ReductionCompany> ReductionCompanies { get; set; }
        public DbSet<ReductionPersonal> ReductionPersonals { get; set; }

    }
}
