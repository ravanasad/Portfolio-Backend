
using MediatR;
using Business.Features.UserAbouts.Dtos;
using AutoMapper;
using Business.Features.UserAbouts.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.UserAbouts.Queries.GetByIdUserAbout
{
    public class GetByIdUserAboutQuery : IRequest<GetByIdUserAboutDto>
    {
        public int Id { get; set; }
        public class GetByIdUserAboutQueryHandler : IRequestHandler<GetByIdUserAboutQuery, GetByIdUserAboutDto>
        {
            private IMapper _mapper;
            private UserAboutBusinessRules _rules;

            public GetByIdUserAboutQueryHandler(IMapper mapper, UserAboutBusinessRules rules)
            {
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<GetByIdUserAboutDto> Handle(GetByIdUserAboutQuery request, CancellationToken cancellationToken)
            {
                UserAbout userAbout = await _rules.UserAboutShouldBeExists(request.Id);
                return _mapper.Map<GetByIdUserAboutDto>(userAbout);
            }
        }
    }
}

