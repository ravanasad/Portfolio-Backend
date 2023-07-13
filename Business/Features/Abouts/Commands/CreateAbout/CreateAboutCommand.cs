using AutoMapper;
using Business.Features.Abouts.Dtos.Command;
using Business.Features.Abouts.Rules;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Features.Abouts.Commands.CreateAbout
{
    public class CreateAboutCommand : IRequest<CreateAboutDto>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, CreateAboutDto>
        {
            private IAboutDal _aboutDal;
            private UserManager<AppUser> _userManager;
            private IMapper _mapper;
            private AboutBusinessRules _rules;
            public CreateAboutCommandHandler(IAboutDal aboutDal, UserManager<AppUser> userManager, IMapper mapper, AboutBusinessRules rules)
            {
                _aboutDal = aboutDal;
                _userManager = userManager;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateAboutDto> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
            {
                AppUser? user = await _rules.CheckUserEmail();

                About about = new() { Name = request.Name, Value = request.Value, User = user };
                var addedAbout = _aboutDal.Add(about);
                await _aboutDal.SaveChangesAsync();
                return _mapper.Map<CreateAboutDto>(addedAbout);
            }
        }
    }
}
