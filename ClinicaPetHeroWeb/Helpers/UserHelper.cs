using ClinicaPetHeroWeb.Data.Entities;
using ClinicaPetHeroWeb.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ClinicaPetHeroWeb.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        // #########################
        // #        FIND USER      #
        // #########################

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }


        //public async Task<User> GetUserByIdAsync(string userId)
        //{
        //    return await _userManager.FindByIdAsync(userId);
        //}


        // ###########################
        // #        CREATE USER      #
        // ###########################

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }


        // ##############################
        // #        LOGIN / LOGOUT      #
        // ##############################

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        // #######################################
        // #        UPDATE USER INFORMATION      #
        // #######################################

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }


        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }


        // #############################
        // #        ROLES METHODS      #
        // #############################

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }


        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }


        public async Task CreateRoleIfNotExistAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                });
            }
        }


        //public async Task<SignInResult> ValidadtePasswordAsync(User user, string password)
        //{
        //    return await _signInManager.CheckPasswordSignInAsync(
        //        user,
        //        password,
        //        false);
        //}


        //public async Task<string> GenerateEmailconfirmationTokenAsync(User user)
        //{
        //    return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //}


        //public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        //{
        //    return await _userManager.ConfirmEmailAsync(user, token);
        //}





        //public async Task<string> GeneratePasswordResetTokenAsync(User user)
        //{
        //    return await _userManager.GeneratePasswordResetTokenAsync(user);
        //}


        //public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        //{
        //    return await _userManager.ResetPasswordAsync(user, token, password);
        //}
    }
}
