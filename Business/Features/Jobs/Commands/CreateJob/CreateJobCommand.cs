
using MediatR;
using Business.Features.Jobs.Dtos;
using AutoMapper;
using Business.Features.Histories.Rules;
using DataAccess.Abstract;
using Business.Features.Jobs.Rules;
using Domain.Entities.Identity;

namespace Business.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<CreateJobDto>
    {
        public string Name { get; set; }
        public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, CreateJobDto>
        {
            private IJobDal _jobDal;
            private IMapper _mapper;
            private JobBusinessRules _rules;

            public CreateJobCommandHandler(IJobDal jobDal, IMapper mapper, JobBusinessRules rules)
            {
                _jobDal = jobDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateJobDto> Handle(CreateJobCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                var addedJob = _jobDal.Add(new() { Name = request.Name, User = user });
                _ = await _jobDal.SaveChangesAsync();
                return _mapper.Map<CreateJobDto>(addedJob);
            }
        }
    }
}

