using AutoMapper;
using Business.Features.Files.Dtos;
using Business.Features.Files.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Files.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GetByIdFileDto, Domain.Entities.Files.File>().ReverseMap();
            CreateMap<GetByIdFileDto, GetListFileDto>().ReverseMap();
            CreateMap<GetListFileDto, GetListFileModel>().ReverseMap();

        }
    }
}
