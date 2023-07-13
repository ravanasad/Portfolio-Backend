
using MediatR;
using Business.Features.Jobs.Dtos;
using AutoMapper;
using Business.Features.Jobs.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Jobs.Queries.GetByIdJob
{
    public class GetByIdJobQuery : IRequest<GetByIdJobDto>
    {
        public int Id { get; set; }
        public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQuery, GetByIdJobDto>
        {
            private IMapper _mapper;
            private JobBusinessRules _rules;
            public GetByIdJobQueryHandler(IMapper mapper, JobBusinessRules rules)
            {
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<GetByIdJobDto> Handle(GetByIdJobQuery request, CancellationToken cancellationToken)
            {
                Job job = await _rules.JobShouldBeExists(request.Id);
                return _mapper.Map<GetByIdJobDto>(job);
            }
        }
    }
}

