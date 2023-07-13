using AutoMapper;
using Business.Features.Blogs.Dtos;
using Business.Features.Blogs.Models;
using DataAccess.Abstract;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Blogs.Queries.GetListBlog
{
    public class GetListBlogQuery : IRequest<GetListBlogModel>
    {
        public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, GetListBlogModel>
        {
            private IBlogDal _blogDal;
            private IMapper _mapper;
            public GetListBlogQueryHandler(IBlogDal blogDal, IMapper mapper)
            {
                _blogDal = blogDal;
                _mapper = mapper;
            }
            public async Task<GetListBlogModel> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
            {
                IList<Blog> blogs= await _blogDal.Table.Include(i=>i.User).ThenInclude(o=>o.UserAbout).ToListAsync(); 
                GetListBlogDto getListBlogDto = new() {Blogs = blogs };
                return _mapper.Map<GetListBlogModel>(getListBlogDto);
            }
        }
    }
}

