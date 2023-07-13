using MediatR;
using Business.Features.Portfolios.Dtos;
using AutoMapper;
using Business.Features.Portfolios.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Business.Services.FileService;
using Business.Constants;

namespace Business.Features.Portfolios.Commands.UpdatePortfolio
{
    public class UpdatePortfolioCommand : IRequest<UpdatePortfolioDto>
    {
        public int Id { get; set; }
        public string Budget { get; set; }
        public string Technologies { get; set; }
        public string Duration { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string SiteLink { get; set; }
        public IFormFile File { get; set; }
        public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, UpdatePortfolioDto>
        {
            private IPortfolioDal _portfolioDal;
            private IMapper _mapper;
            private PortfolioBusinessRules _rules;
            private IFileService _fileService;
            public UpdatePortfolioCommandHandler(IPortfolioDal portfolioDal, IMapper mapper, PortfolioBusinessRules rules, IFileService fileService)
            {
                _portfolioDal = portfolioDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<UpdatePortfolioDto> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
            {
                Portfolio mappedPortfolio = _mapper.Map<Portfolio>(request);
                _ = await _rules.PortfolioShouldBeExists(request.Id);
                Portfolio updatedPortfolio = _portfolioDal.Update(mappedPortfolio);
                if(request.File != null)
                {
                    string path = "";
                    if (updatedPortfolio.ImagePath != string.Empty)
                        path = await _fileService.UpdateAsync(ImageFileType.PortfolioFolder, updatedPortfolio.ImagePath, request.File);
                    else
                        path = await _fileService.UploadAsync(ImageFileType.PortfolioFolder, request.File);
                    updatedPortfolio.ImagePath = path;
                }
                _ = await _portfolioDal.SaveChangesAsync();
                return _mapper.Map<UpdatePortfolioDto>(updatedPortfolio);
            }
        }
    }
}

