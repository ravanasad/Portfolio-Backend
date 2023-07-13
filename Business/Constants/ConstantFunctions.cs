using Business.Exceptions;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Constants
{
    public class ConstantFunctions
    {
        private IHttpContextAccessor _context;
        private UserManager<AppUser> _userManager;
        public ConstantFunctions(IHttpContextAccessor context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AppUser> CheckUserEmail()
        {
            string userEmail = _context.HttpContext.User.Identity.Name;
            if (userEmail == null)
                throw new Exception("Something went wrong");

            AppUser? user = await _userManager.FindByEmailAsync(userEmail);
            await UserShouldBeExists(user);
            return user;
        }
        public Task UserShouldBeExists(AppUser? appUser)
        {
            if (appUser == null) throw new NotFoundUserException();
            return Task.CompletedTask;
        }

    }
}
