
using MediatR;
using Business.Features.Portfolios.Dtos;
using AutoMapper;
using DataAccess.Abstract;
using Business.Features.Portfolios.Rules;
using Domain.Entities;
using Business.Services.FileService;

namespace Business.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommand : IRequest<DeletePortfolioDto>
    {
        public int Id { get; set; }
        public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, DeletePortfolioDto>
        {
            private IPortfolioDal _portfolioDal;
            private IMapper _mapper;
            private PortfolioBusinessRules _rules;
            private IFileService _fileService;

            public DeletePortfolioCommandHandler(IMapper mapper, PortfolioBusinessRules rules, IPortfolioDal portfolioDal, IFileService fileService)
            {
                _mapper = mapper;
                _rules = rules;
                _portfolioDal = portfolioDal;
                _fileService = fileService;
            }

            public async Task<DeletePortfolioDto> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
            {
                Portfolio portfolio = await _rules.PortfolioShouldBeExists(request.Id);
                var deletedPortfolio = _portfolioDal.Delete(portfolio);
                if (deletedPortfolio.ImagePath != string.Empty)
                    await _fileService.DeleteAsync(portfolio.ImagePath);
                _ = await _portfolioDal.SaveChangesAsync();
                return _mapper.Map<DeletePortfolioDto>(deletedPortfolio);
            }
        }
    }
}

