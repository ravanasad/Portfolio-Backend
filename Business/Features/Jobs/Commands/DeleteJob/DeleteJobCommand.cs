using MediatR;
using Business.Features.Jobs.Dtos;
using AutoMapper;
using Business.Features.Jobs.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Jobs.Commands.DeleteJob
{
    public class DeleteJobCommand : IRequest<DeleteJobDto>
    {
        public int Id { get; set; }
        public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, DeleteJobDto>
        {
            private IJobDal _jobDal;
            private IMapper _mapper;
            private JobBusinessRules _rules;

            public DeleteJobCommandHandler(IJobDal jobDal, IMapper mapper, JobBusinessRules rules)
            {
                _jobDal = jobDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<DeleteJobDto> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
            {
                Job job = await _rules.JobShouldBeExists(request.Id);
                var deletedJob = _jobDal.Delete(job);
                _ = await _jobDal.SaveChangesAsync();
                return _mapper.Map<DeleteJobDto>(deletedJob);
            }
        }
    }
}

