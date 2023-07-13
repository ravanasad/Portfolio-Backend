using AutoMapper;
using Business.Features.UserAbouts.Commands.CreateUserAbout;
using Business.Features.UserAbouts.Commands.UpdateUserAbout;
using Business.Features.UserAbouts.Dtos;
using Business.Features.UserAbouts.Models;
using Domain.Entities;

namespace Business.Features.UserAbouts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserAbout, CreateUserAboutCommand>().ReverseMap();
            CreateMap<UserAbout, CreateUserAboutDto>().ReverseMap();
            CreateMap<UserAbout, DeleteUserAboutDto>().ReverseMap();
            CreateMap<UserAbout, UpdateUserAboutDto>().ReverseMap();
            CreateMap<UserAbout, UpdateUserAboutCommand>().ReverseMap();

            CreateMap<UserAbout, GetByIdUserAboutDto>().ForPath(i => i.Email, opt => opt.MapFrom(src => src.AppUser.Email)).ReverseMap();
            CreateMap<GetListUserAboutModel, GetListUserAboutDto>().ReverseMap();
        }
    }
}
