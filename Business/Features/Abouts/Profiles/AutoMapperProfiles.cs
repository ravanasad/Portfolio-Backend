using AutoMapper;
using Business.Features.Abouts.Dtos.Command;
using Business.Features.Abouts.Dtos.Query;
using Business.Features.Abouts.Models;
using Domain.Entities;

namespace Business.Features.Abouts.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, DeleteAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<About, GetByIdAboutDto>().ForPath(i => i.Email, opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
            CreateMap<GetListAboutModel, GetListAboutDto>().ReverseMap();

        }
    }
}
