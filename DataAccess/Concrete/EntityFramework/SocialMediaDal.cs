using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class SocialMediaDal : EfEntityRepositoryBase<SocialMedia>, ISocialMediaDal
    {
        public SocialMediaDal(BaseContext context) : base(context)
        {
        }
    }
}
