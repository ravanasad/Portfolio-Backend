using AutoMapper;
using Business.Constants;
using Business.Features.Blogs.Dtos;
using Business.Features.Blogs.Rules;
using Business.Services.FileService;
using Business.Services.Storage;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;

namespace Business.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<UpdateBlogDto>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdateBlogDto>
        {
            private IBlogDal _blogDal;
            private IMapper _mapper;
            private BlogBusinessRules _rules;
            private IFileService _fileService;
            public UpdateBlogCommandHandler(IBlogDal blogDal, IMapper mapper, BlogBusinessRules rules, IFileService fileService)
            {
                _blogDal = blogDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<UpdateBlogDto> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                var blog = await _blogDal.GetByIdAsync(request.Id);
                blog.Description = request.Description;
                blog.Header = request.Header;
                blog.Date = DateTime.UtcNow;
                if (request.File != null)
                {
                    string path = "";
                    if (blog.ImagePath != string.Empty)
                        path = await _fileService.UpdateAsync(ImageFileType.BlogFolder, blog.ImagePath, request.File);
                    else
                        path = await _fileService.UploadAsync(ImageFileType.BlogFolder, request.File);
                    blog.ImagePath = path;
                }
                var updatedBlog = _blogDal.Update(blog);
                _ = await _blogDal.SaveChangesAsync();
                return _mapper.Map<UpdateBlogDto>(updatedBlog);
            }
        }
    }
}

