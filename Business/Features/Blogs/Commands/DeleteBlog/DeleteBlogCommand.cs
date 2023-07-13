using AutoMapper;
using Business.Features.Blogs.Dtos;
using Business.Services.FileService;
using Business.Services.Storage;
using DataAccess.Abstract;
using MediatR;

namespace Business.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<DeleteBlogDto>
    {
        public int Id { get; set; }
        public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, DeleteBlogDto>
        {
            private IBlogDal _blogDal;
            private IMapper _mapper;
            private IFileService _fileService;
            public DeleteBlogCommandHandler(IBlogDal blogDal, IMapper mapper, IFileService fileService)
            {
                _blogDal = blogDal;
                _mapper = mapper;
                _fileService = fileService;
            }

            public async Task<DeleteBlogDto> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = await _blogDal.GetByIdAsync(request.Id);
                var deletedBlog = _blogDal.Delete(blog);
                if(deletedBlog.ImagePath != string.Empty) 
                    await _fileService.DeleteAsync(deletedBlog.ImagePath);

                _ = await _blogDal.SaveChangesAsync();
                return _mapper.Map<DeleteBlogDto>(deletedBlog);
            }
        }
    }
}

