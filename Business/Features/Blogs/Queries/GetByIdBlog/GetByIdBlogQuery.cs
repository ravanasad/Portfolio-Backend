using MediatR;
using Business.Features.Blogs.Dtos;
using DataAccess.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Blogs.Queries.GetByIdBlog
{
    public class GetByIdBlogQuery : IRequest<GetByIdBlogDto>
    {
        public int Id { get; set; }
        public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, GetByIdBlogDto>
        {
            private IBlogDal _blogDal;
            private IMapper _mapper;
            public GetByIdBlogQueryHandler(IBlogDal blogDal, IMapper mapper)
            {
                _blogDal = blogDal;
                _mapper = mapper;
            }
            public async Task<GetByIdBlogDto> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
            {
                var blog = await _blogDal.Table.Include(i=>i.User).ThenInclude(i=>i.UserAbout).FirstOrDefaultAsync(i=>i.Id==request.Id);
                return _mapper.Map<GetByIdBlogDto>(blog);
            }
        }
    }
}

