
namespace Repository.Models
{
    public class Role : Microsoft.AspNetCore.Identity.IdentityRole<int>
    {

    }
    public enum RoleEnum
    {
        SuperAdmin,
        Admin,
        User
    }
}
