
using Business.Constants;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Skills.Rules
{
    public class SkillBusinessRules : ConstantFunctions
    {
        private ISkillDal _skillDal;
        public SkillBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager, ISkillDal skillDal = null) : base(context, userManager)
        {
            _skillDal = skillDal;
        }

        public async Task<Skill> SkillShouldBeExists(int id)
        {
            Skill skill = await _skillDal.Table.Include(i => i.User).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            if (skill is null)
                throw new Exception("Skill not found");
            return skill;
        }
    }
}
