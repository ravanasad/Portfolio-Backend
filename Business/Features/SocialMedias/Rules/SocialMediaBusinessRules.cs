
using Business.Constants;
using DataAccess.Abstract;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.SocialMedias.Rules;

public class SocialMediaBusinessRules : ConstantFunctions
{
    private ISocialMediaDal _socialMediaDal;
    public SocialMediaBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager, ISocialMediaDal socialMediaDal = null) : base(context, userManager)
    {
        _socialMediaDal = socialMediaDal;
    }

    public async Task<SocialMedia> SocialMediaShouldBeExists(int id)
    {
        SocialMedia socialMedia =await _socialMediaDal.Table.Include(i=>i.User).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        if (socialMedia == null)
            throw new Exception("SocialMedia not found");
        return socialMedia;
    }
}
