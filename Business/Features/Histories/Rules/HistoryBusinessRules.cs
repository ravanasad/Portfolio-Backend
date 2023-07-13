
using Business.Constants;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Features.Histories.Rules;

public class HistoryBusinessRules : ConstantFunctions
{
    public HistoryBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager) : base(context, userManager)
    {
    }
    public Task HistoryShouldBeExists(History history)
    {
        if (history is null)
            throw new Exception("History not found");
        return Task.CompletedTask;
    }
}
