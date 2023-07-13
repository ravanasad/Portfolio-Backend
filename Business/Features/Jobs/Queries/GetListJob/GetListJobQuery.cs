
using MediatR;
using Business.Features.Jobs.Dtos;
using AutoMapper;
using Business.Features.Jobs.Rules;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Business.Features.Jobs.Models;
using System.Collections;

namespace Business.Features.Jobs.Queries.GetListJob
{
    public class GetListJobQuery : IRequest<GetListJobModel>
    {
        public class GetListJobQueryHandler : IRequestHandler<GetListJobQuery, GetListJobModel>
        {
            private IMapper _mapper;
            private IJobDal _jobDal;
            public GetListJobQueryHandler(IJobDal jobDal, IMapper mapper)
            {
                _mapper = mapper;
                _jobDal = jobDal;
            }
            public async Task<GetListJobModel> Handle(GetListJobQuery request, CancellationToken cancellationToken)
            {
                List<Job> JobList = await _jobDal.Table.Include(i => i.User).ToListAsync();
                ArrayList jobs = new();
                foreach (var item in JobList)
                {
                    jobs.Add(item.Name);
                    jobs.Add(3000);
                }

                return new() { Jobs = jobs };
            }
        }
    }
}