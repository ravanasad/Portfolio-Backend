using AutoMapper;
using Business.Features.Skills.Commands.CreateSkill;
using Business.Features.Skills.Commands.UpdateSkill;
using Business.Features.Skills.Dtos;
using Business.Features.Skills.Models;
using Domain.Entities;

namespace Business.Features.Skills.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Skill, CreateSkillDto>().ReverseMap();
            CreateMap<Skill, CreateSkillCommand>().ReverseMap();
            CreateMap<Skill, DeleteSkillDto>().ReverseMap();
            CreateMap<Skill, UpdateSkillDto>().ReverseMap();
            CreateMap<Skill, UpdateSkillCommand>().ReverseMap();

            CreateMap<Skill, GetByIdSkillDto>().ForPath(i => i.Email, opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
            CreateMap<GetListSkillModel, GetListSkillDto>().ReverseMap();
        }
    }
}
