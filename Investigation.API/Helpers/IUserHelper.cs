using Investigation.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Investigation.API.Helpers
{
    public interface IUserHelper

    {
        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AdduserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}
