using AutoMapper;
using Business.Features.Histories.Commands.UpdateHistory;
using Business.Features.Histories.Dtos;
using Business.Features.Histories.Models;
using Domain.Entities;

namespace Business.Features.Histories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<History, CreateHistoryDto>().ForPath(i=>i.Email , opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
            CreateMap<History, DeleteHistoryDto>().ReverseMap();
            CreateMap<History, UpdateHistoryDto>().ReverseMap();
            CreateMap<History, UpdateHistoryCommand>().ReverseMap();

            CreateMap<History, GetByIdHistoryDto>().ForPath(i => i.Email, opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
            CreateMap<GetListHistoryModel, GetListHistoryDto>().ReverseMap();
        }
    }
}
