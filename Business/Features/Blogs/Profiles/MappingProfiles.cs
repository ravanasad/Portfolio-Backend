
using AutoMapper;
using Business.Features.Blogs.Dtos;
using Business.Features.Blogs.Models;
using Domain.Entities;

namespace Business.Features.Blogs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, DeleteBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();

            CreateMap<Blog, GetByIdBlogDto>().ForPath(i=>i.Email,j=>j.MapFrom(y=>y.User.Email))
                .ForPath(i => i.ProfileImage, j => j.MapFrom(y => y.User.UserAbout.ImagePath)).ReverseMap();
            CreateMap<GetListBlogModel, GetListBlogDto>().ReverseMap();
        }
    }
}
