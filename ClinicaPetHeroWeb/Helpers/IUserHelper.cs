using ClinicaPetHeroWeb.Data.Entities;
using ClinicaPetHeroWeb.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ClinicaPetHeroWeb.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CreateRoleIfNotExistAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        //Task<SignInResult> ValidadtePasswordAsync(User user, string password);

        //Task<string> GenerateEmailconfirmationTokenAsync(User user);

        //Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        //Task<User> GetUserByIdAsync(string userId);

        //Task<string> GeneratePasswordResetTokenAsync(User user);

        //Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);
    }
}
