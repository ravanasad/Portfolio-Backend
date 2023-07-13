using MediatR;
using Business.Features.Skills.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using AutoMapper;
using Business.Features.Skills.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Skills.Commands.DeleteSkill
{
    public class DeleteSkillCommand : IRequest<DeleteSkillDto>
    {
        public int Id { get; set; }
        public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, DeleteSkillDto>
        {
            private ISkillDal _skillDal;
            private IMapper _mapper;
            private SkillBusinessRules _rules;
            public DeleteSkillCommandHandler(ISkillDal skillDal, IMapper mapper, SkillBusinessRules rules)
            {
                _skillDal = skillDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<DeleteSkillDto> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
            {
                Skill skill = await _rules.SkillShouldBeExists(request.Id);
                var deletedSkill = _skillDal.Delete(skill);
                _ = await _skillDal.SaveChangesAsync();
                return _mapper.Map<DeleteSkillDto>(deletedSkill);
            }
        }
    }
}

