using Domain.Entities;

namespace Business.Features.Blogs.Dtos
{
    public class GetListBlogDto
    {
        public IList<Blog> Blogs { get; set; }
    }
}
