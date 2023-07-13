using Business.Constants;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Abouts.Rules
{
    public class AboutBusinessRules : ConstantFunctions
    {
        public AboutBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager) : base(context, userManager)
        {
        }

        public Task AboutShouldBeExists(About? about)
        {
            if (about == null) throw new Exception("About not exists.");
            return Task.CompletedTask;
        }
    }
}
