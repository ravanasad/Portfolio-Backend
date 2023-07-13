using Business.Exceptions;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Business.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AuthBusinessRules(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppUser> UserShouldBeExists(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            return user ?? throw new NotFoundUserException();
        }
        public async Task<AppUser> UserShouldBeExists(int id)
        {
            AppUser? user = await _userManager.FindByIdAsync(id.ToString());
            return user ?? throw new NotFoundUserException();
        }
        public async Task<SignInResult> CheckPassword(AppUser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result ?? throw new Exception("Email or Password is incorrect");
        }
        public async Task<List<string>> CheckAndAddRole(AppUser user, List<string> roles)
        {
            foreach (var role in roles)
                if (!(await _userManager.GetUsersInRoleAsync(role) == IdentityResult.Success))
                    await _userManager.AddToRoleAsync(user, role);
                else
                    roles.Remove(role);
            return roles;
        }
        public async Task<AppUser> UserShouldBeNotExists(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return user;

            throw new NotFoundUserException();
        }

    }
}
