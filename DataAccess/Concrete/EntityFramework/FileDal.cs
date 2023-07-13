using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class FileDal : EfEntityRepositoryBase<Domain.Entities.Files.File>, IFileDal
    {
        public FileDal(BaseContext context) : base(context)
        {
        }
    }
}
