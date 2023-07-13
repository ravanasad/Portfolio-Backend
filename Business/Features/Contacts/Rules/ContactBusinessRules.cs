
using Business.Constants;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Business.Features.Contacts.Rules
{
    public class ContactBusinessRules : ConstantFunctions
    {
        public ContactBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager) : base(context, userManager)
        {
           
        }

        public Task ContactShouldBeExists(Contact contact)
        {
            if (contact is null) throw new Exception("Contact is null");
            return Task.CompletedTask;
        }
    }
}