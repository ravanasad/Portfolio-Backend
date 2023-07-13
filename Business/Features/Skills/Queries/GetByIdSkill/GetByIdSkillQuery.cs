
using MediatR;
using Business.Features.Skills.Dtos;
using AutoMapper;
using DataAccess.Abstract;
using Business.Features.Skills.Rules;
using Domain.Entities;

namespace Business.Features.Skills.Queries.GetByIdSkill
{
    public class GetByIdSkillQuery : IRequest<GetByIdSkillDto>
    {
        public int Id { get; set; }
        public class GetByIdSkillQueryHandler : IRequestHandler<GetByIdSkillQuery, GetByIdSkillDto>
        {
            private IMapper _mapper;
            private SkillBusinessRules _rules;

            public GetByIdSkillQueryHandler(IMapper mapper, SkillBusinessRules rules)
            {
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<GetByIdSkillDto> Handle(GetByIdSkillQuery request, CancellationToken cancellationToken)
            {
                Skill skill = await _rules.SkillShouldBeExists(request.Id);
                return _mapper.Map<GetByIdSkillDto>(skill);
            }
        }
    }
}

