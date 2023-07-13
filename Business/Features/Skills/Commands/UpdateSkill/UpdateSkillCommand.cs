
using MediatR;
using Business.Features.Skills.Dtos;
using AutoMapper;
using Business.Features.Skills.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommand : IRequest<UpdateSkillDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Value { get; set; }
        public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, UpdateSkillDto>
        {
            private ISkillDal _skillDal;
            private IMapper _mapper;
            private SkillBusinessRules _rules;

            public UpdateSkillCommandHandler(ISkillDal skillDal, IMapper mapper, SkillBusinessRules rules)
            {
                _skillDal = skillDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdateSkillDto> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
            {
                Skill skill = await _rules.SkillShouldBeExists(request.Id);
                skill.Value = request.Value;
                skill.Name = request.Name;
                var updatedSkill = _skillDal.Update(skill);
                _ = await _skillDal.SaveChangesAsync();
                return _mapper.Map<UpdateSkillDto>(updatedSkill);
            }
        }
    }
}

