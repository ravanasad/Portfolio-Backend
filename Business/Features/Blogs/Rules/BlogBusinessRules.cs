using Business.Constants;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Features.Blogs.Rules
{
    public class BlogBusinessRules : ConstantFunctions
    {
        public BlogBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager) : base(context, userManager)
        {
        }
    }
}
