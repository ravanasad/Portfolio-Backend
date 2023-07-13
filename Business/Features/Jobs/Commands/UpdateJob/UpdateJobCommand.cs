
using MediatR;
using Business.Features.Jobs.Dtos;
using AutoMapper;
using Business.Features.Jobs.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommand : IRequest<UpdateJobDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, UpdateJobDto>
        {
            private IJobDal _jobDal;
            private IMapper _mapper;
            private JobBusinessRules _rules;

            public UpdateJobCommandHandler(IJobDal jobDal, IMapper mapper, JobBusinessRules rules)
            {
                _jobDal = jobDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdateJobDto> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
            {
                Job job = await _rules.JobShouldBeExists(request.Id);
                job.Name= request.Name;
                Job updatedJob = _jobDal.Update(job);
                _ = await _jobDal.SaveChangesAsync();
                return _mapper.Map<UpdateJobDto>(updatedJob);
            }
        }
    }
}

