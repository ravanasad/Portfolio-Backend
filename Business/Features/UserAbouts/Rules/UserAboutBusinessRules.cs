using Business.Constants;
using DataAccess.Abstract;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.UserAbouts.Rules
{

    public class UserAboutBusinessRules : ConstantFunctions
    {
        private IUserAboutDal _userAboutDal;
        public UserAboutBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager, IUserAboutDal userAboutDal = null) : base(context, userManager)
        {
            _userAboutDal = userAboutDal;
        }
        public async Task<UserAbout> UserAboutShouldBeExists(int id)
        {
            UserAbout userAbout =  await _userAboutDal.Table.Include(i=>i.AppUser).AsNoTracking().FirstOrDefaultAsync(i=>i.Id==id);
            if (userAbout == null)
                throw new Exception("User about not found");
            return userAbout;
        }
    }
}
