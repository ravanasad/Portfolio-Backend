
using AutoMapper;
using Business.Features.Portfolios.Commands.CreatePortfolio;
using Business.Features.Portfolios.Commands.UpdatePortfolio;
using Business.Features.Portfolios.Dtos;
using Business.Features.Portfolios.Models;

using Domain.Entities;

namespace Business.Features.Portfolios.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Portfolio, CreatePortfolioDto>().ReverseMap();
            CreateMap<Portfolio, CreatePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, DeletePortfolioDto>().ReverseMap();
            CreateMap<Portfolio, UpdatePortfolioDto>().ReverseMap();
            CreateMap<Portfolio, UpdatePortfolioCommand>().ReverseMap();

            CreateMap<Portfolio, GetByIdPortfolioDto>().ForPath(i => i.Email, opt => opt.MapFrom(src => src.User.Email)).ReverseMap();
            CreateMap<Portfolio, Domain.Entities.Files.File>().ReverseMap();
            CreateMap<Portfolio, (GetByIdPortfolioDto,Domain.Entities.Files.File)>().ReverseMap();
            CreateMap<GetListPortfolioModel, GetListPortfolioDto>().ReverseMap();
        }
    }
}
