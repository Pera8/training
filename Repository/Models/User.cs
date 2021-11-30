
using Microsoft.AspNetCore.Identity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class User : IdentityUser<int>, IBaseModel
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public RoleEnum RoleEnum { get; set; }


    }
}
