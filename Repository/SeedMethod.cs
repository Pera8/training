using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SeedMethod
    {
        private AppDbContext _context;

        public SeedMethod(AppDbContext context)
        {
            _context = context;
        }


        public static void Initialize(IServiceProvider serviceProvider)
        {
            //string[] roles = new string[] { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };

            //foreach (string role in roles)
            //{
            //    var roleStore = new RoleStore<Role>(_context);

            //    if (!_context.Roles.Any(r => r.Name == role))
            //    {
            //        roleStore.CreateAsync(new IdentityRole(role));
            //    }
            //}
            //context.SaveChangesAsync();
        }

    }
}
