using Business.Constants;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Portfolios.Rules;

public class PortfolioBusinessRules : ConstantFunctions
{
    private IPortfolioDal _portfolioDal;

    public PortfolioBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager, IPortfolioDal portfolioDal = null) : base(context, userManager)
    {
        _portfolioDal = portfolioDal;
    }

    public async Task<Portfolio> PortfolioShouldBeExists(int id)
    {
        Portfolio portfolio = await _portfolioDal.Table.Include(i=>i.User).AsNoTracking().FirstOrDefaultAsync(i=>i.Id== id);
        if (portfolio == null)
            throw new Exception("Portfolio not found");
        return portfolio;
    }
}
