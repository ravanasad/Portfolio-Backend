using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserAboutDal : EfEntityRepositoryBase<UserAbout>, IUserAboutDal
    {
        public UserAboutDal(BaseContext context) : base(context)
        {
        }
    }
}
