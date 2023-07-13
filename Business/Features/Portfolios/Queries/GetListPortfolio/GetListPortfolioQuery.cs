using MediatR;
using Business.Features.Portfolios.Dtos;
using AutoMapper;
using Business.Features.Portfolios.Rules;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Business.Features.Portfolios.Models;
using Domain.Enums;

namespace Business.Features.Portfolios.Queries.GetListPortfolio
{
    public class GetListPortfolioQuery : IRequest<GetListPortfolioModel>
    {
        public class GetListPortfolioQueryHandler : IRequestHandler<GetListPortfolioQuery, GetListPortfolioModel>
        {
            private IPortfolioDal _portfolioDal;
            private IMapper _mapper;
            private PortfolioBusinessRules _rules;
            private IFileDal _fileDal;
            public GetListPortfolioQueryHandler(IPortfolioDal portfolioDal, IMapper mapper, PortfolioBusinessRules rules, IFileDal fileDal)
            {
                _portfolioDal = portfolioDal;
                _mapper = mapper;
                _rules = rules;
                _fileDal = fileDal;
            }

            public async Task<GetListPortfolioModel> Handle(GetListPortfolioQuery request, CancellationToken cancellationToken)
            {
                List<Portfolio> portfolios = await _portfolioDal.Table.Include(i => i.User).ToListAsync();
                GetListPortfolioDto getListPortfolioDto = new()
                {
                    Portfolios=portfolios
                };
                return _mapper.Map<GetListPortfolioModel>(getListPortfolioDto);
            }
        }
    }
}

