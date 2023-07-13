
using MediatR;
using Business.Features.Portfolios.Dtos;
using AutoMapper;
using Business.Features.Portfolios.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;

namespace Business.Features.Portfolios.Queries.GetByIdPortfolio
{
    public class GetByIdPortfolioQuery : IRequest<GetByIdPortfolioDto>
    {
        public int Id { get; set; }
        public class GetByIdPortfolioQueryHandler : IRequestHandler<GetByIdPortfolioQuery, GetByIdPortfolioDto>
        {
            private IMapper _mapper;
            private PortfolioBusinessRules _rules;
            public GetByIdPortfolioQueryHandler(IMapper mapper, PortfolioBusinessRules rules)
            {
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<GetByIdPortfolioDto> Handle(GetByIdPortfolioQuery request, CancellationToken cancellationToken)
            {
                Portfolio portfolio = await _rules.PortfolioShouldBeExists(request.Id);
                return _mapper.Map<GetByIdPortfolioDto>(portfolio);
            }
        }
    }
}

