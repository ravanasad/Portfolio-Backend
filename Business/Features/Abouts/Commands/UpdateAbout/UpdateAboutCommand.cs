using AutoMapper;
using Business.Features.Abouts.Dtos.Command;
using Business.Features.Abouts.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using MediatR;

namespace Business.Features.Abouts.Commands.UpdateAbout
{
    public class UpdateAboutCommand : IRequest<UpdateAboutDto>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }


        public class UpdateAboudCommandHandler : IRequestHandler<UpdateAboutCommand, UpdateAboutDto>
        {
            private IAboutDal _aboutDal;
            private IMapper _mapper;
            private AboutBusinessRules _rules;
            public UpdateAboudCommandHandler(IAboutDal aboutDal, IMapper mapper, AboutBusinessRules rules)
            {
                _aboutDal = aboutDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdateAboutDto> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
            {
                About about = await _aboutDal.GetByIdAsync(request.Id);
                await _rules.AboutShouldBeExists(about);

                about.Name = request.Name;
                about.Value = request.Value;

                await _aboutDal.SaveChangesAsync();
                return _mapper.Map<UpdateAboutDto>(about);
            }
        }
    }
}
