
using MediatR;
using Business.Features.Portfolios.Dtos;
using DataAccess.Abstract;
using AutoMapper;
using Business.Features.Portfolios.Rules;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Business.Services.FileService;
using Business.Constants;

namespace Business.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<CreatePortfolioDto>
    {
        public string Budget { get; set; }
        public string Technologies { get; set; }
        public string Duration { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string SiteLink { get; set; }
        public IFormFile File { get; set; }
        public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, CreatePortfolioDto>
        {
            private IPortfolioDal _portfolioDal;
            private IMapper _mapper;
            private PortfolioBusinessRules _rules;
            private IFileService _fileService;
            public CreatePortfolioCommandHandler(IPortfolioDal portfolioDal, IMapper mapper, PortfolioBusinessRules rules, IFileService fileService)
            {
                _portfolioDal = portfolioDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<CreatePortfolioDto> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                Portfolio mappedRequest = _mapper.Map<Portfolio>(request);
                mappedRequest.User = user;
                var addedPortfolio = _portfolioDal.Add(mappedRequest);
                if(request.File is not null)
                {
                    string path = await _fileService.UploadAsync(ImageFileType.PortfolioFolder, request.File);
                    addedPortfolio.ImagePath = path;
                }
                _ = await _portfolioDal.SaveChangesAsync();
                return _mapper.Map<CreatePortfolioDto>(addedPortfolio);
            }
        }
    }
}

