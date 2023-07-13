using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class JobDal : EfEntityRepositoryBase<Job>, IJobDal
    {
        public JobDal(BaseContext context) : base(context)
        {
        }
    }
}
