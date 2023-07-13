
using AutoMapper;
using Business.Features.Histories.Dtos;
using Business.Features.Histories.Models;
using Business.Features.Jobs.Commands.UpdateJob;
using Business.Features.Jobs.Dtos;
using Business.Features.Jobs.Models;
using Domain.Entities;

namespace Business.Features.Jobs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Job, CreateJobDto>().ReverseMap();
            CreateMap<Job, DeleteJobDto>().ReverseMap();
            CreateMap<Job, UpdateJobDto>().ReverseMap();
            CreateMap<Job, UpdateJobCommand>().ReverseMap();

            CreateMap<Job, GetByIdJobDto>().ReverseMap();
            CreateMap<GetListJobModel, GetListJobDto>().ReverseMap();
        }
    }
}