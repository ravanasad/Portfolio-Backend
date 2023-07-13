using Business.Constants;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Jobs.Rules
{
    public class JobBusinessRules : ConstantFunctions
    {
        private IJobDal _jobDal;
        public JobBusinessRules(IHttpContextAccessor context, UserManager<AppUser> userManager, IJobDal jobDal) : base(context, userManager)
        {
            _jobDal = jobDal;
        }
        public async Task<Job> JobShouldBeExists(int id)
        {
            var job  = await _jobDal.Table.Include(i => i.User).FirstOrDefaultAsync(i => i.Id == id);
            if (job == null)
                throw new Exception("Job not found");

            return job;

        }
    }
}