
using MediatR;
using Business.Features.Skills.Dtos;
using AutoMapper;
using Business.Features.Skills.Rules;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Business.Features.Skills.Models;

namespace Business.Features.Skills.Queries.GetListSkill
{
    public class GetListSkillQuery : IRequest<GetListSkillModel>
    {
        public class GetListSkillQueryHandler : IRequestHandler<GetListSkillQuery, GetListSkillModel>
        {
            private IMapper _mapper;
            private SkillBusinessRules _rules;
            private ISkillDal _skillDal;

            public GetListSkillQueryHandler(ISkillDal skillDal, SkillBusinessRules rules = null, IMapper mapper = null)
            {
                _skillDal = skillDal;
                _rules = rules;
                _mapper = mapper;
            }

            public async Task<GetListSkillModel> Handle(GetListSkillQuery request, CancellationToken cancellationToken)
            {
                List<Skill> skills = await _skillDal.Table.Include(i => i.User).ToListAsync();
                GetListSkillDto getListSkillDto = new() { Skills= skills };
                return _mapper.Map<GetListSkillModel>(getListSkillDto);
            }
        }
    }
}

