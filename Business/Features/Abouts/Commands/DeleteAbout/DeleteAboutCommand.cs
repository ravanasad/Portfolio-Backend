using AutoMapper;
using Business.Features.Abouts.Dtos.Command;
using Business.Features.Abouts.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using MediatR;

namespace Business.Features.Abouts.Commands.DeleteAbout
{
    public class DeleteAboutCommand : IRequest<DeleteAboutDto>
    {
        public int Id { get; set; }
        class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, DeleteAboutDto>
        {
            private IAboutDal _aboutDal;
            private IMapper _mapper;
            private AboutBusinessRules _rules;

            public DeleteAboutCommandHandler(IAboutDal aboutDal, IMapper mapper, AboutBusinessRules rules)
            {
                _aboutDal = aboutDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<DeleteAboutDto> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
            {
                About about = await _aboutDal.GetByIdAsync(request.Id);
                await _rules.AboutShouldBeExists(about);

                var deletedAbout = _aboutDal.Delete(about);
                await _aboutDal.SaveChangesAsync();

                return _mapper.Map<DeleteAboutDto>(deletedAbout);
            }
        }
    }
}
