using AutoMapper;
using Business.Features.Blogs.Dtos;
using Business.Features.Blogs.Rules;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Business.Services.Storage;
using Business.Constants;
using Business.Services.FileService;

namespace Business.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<CreateBlogDto>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string Categories { get; set; }
        public IFormFile File { get; set; }
        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreateBlogDto>
        {
            private IBlogDal _blogDal;
            private IMapper _mapper;
            private BlogBusinessRules _rules;
            private IFileService _fileService;
            public CreateBlogCommandHandler(IBlogDal blogDal, IMapper mapper, BlogBusinessRules rules, IFileService fileService)
            {
                _blogDal = blogDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<CreateBlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                AppUser? user = await _rules.CheckUserEmail();
                Blog blog = new()
                {
                    Date = DateTime.UtcNow,
                    Description = request.Description,
                    About = request.About,
                    Categories = request.Categories,
                    Header = request.Header,
                    User = user

                };
                if (request.File != null)
                {
                    string path = await _fileService.UploadAsync(ImageFileType.BlogFolder, request.File);
                    blog.ImagePath = path;
                }
                var createdBlog = _blogDal.Add(blog);
                await _blogDal.SaveChangesAsync();
                return _mapper.Map<CreateBlogDto>(createdBlog);
            }
        }
    }
}