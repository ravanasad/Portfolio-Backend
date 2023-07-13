using AutoMapper;
using Business.Features.Skills.Dtos;
using Business.Features.Skills.Rules;
using DataAccess.Abstract;
using Domain.Entities.Identity;
using Domain.Entities;
using MediatR;

namespace Business.Features.Skills.Commands.CreateSkill
{
    public class CreateSkillCommand : IRequest<CreateSkillDto>
    {
        public string Name { get; set; }
        public byte Value { get; set; }

        public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, CreateSkillDto>
        {
            private ISkillDal _skillDal;
            private IMapper _mapper;
            private SkillBusinessRules _rules;
            public CreateSkillCommandHandler(ISkillDal skillDal, IMapper mapper, SkillBusinessRules rules)
            {
                _skillDal = skillDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateSkillDto> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                Skill skill = _mapper.Map<Skill>(request);
                skill.User = user;
                var addedSkill = _skillDal.Add(skill);
                _ = await _skillDal.SaveChangesAsync();
                return _mapper.Map<CreateSkillDto>(addedSkill);
            }
        }
    }
}

