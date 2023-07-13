using AutoMapper;
using Business.Features.SocialMedias.Commands.CreateSocialMedia;
using Business.Features.SocialMedias.Commands.UpdateSocialMedia;
using Business.Features.SocialMedias.Dtos;
using Business.Features.SocialMedias.Models;
using Domain.Entities;

namespace Business.Features.SocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, GetByIdSocialMediaDto>().ForPath(i => i.Email, opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
            CreateMap<GetListSocialMediaModel, GetListSocialMediaDto>().ReverseMap();
        }
    }
}
