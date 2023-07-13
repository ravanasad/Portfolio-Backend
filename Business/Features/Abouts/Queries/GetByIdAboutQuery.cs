using AutoMapper;
using Business.Features.Abouts.Dtos.Query;
using Business.Features.Abouts.Rules;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Abouts.Queries
{
    public class GetByIdAboutQuery : IRequest<GetByIdAboutDto>
    {
        public int Id { get; set; }
        public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutDto>
        {
            //todo include 
            private IAboutDal _aboutDal;
            private BaseContext _context;
            private IMapper _mapper;
            private AboutBusinessRules _rules;
            public GetByIdAboutQueryHandler(IAboutDal aboutDal, IMapper mapper, BaseContext context, AboutBusinessRules rules)
            {
                _aboutDal = aboutDal;
                _mapper = mapper;
                _context = context;
                _rules = rules;
            }

            public async Task<GetByIdAboutDto> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
            {
                About? about = await _context.Set<About>().Include(i=>i.User).FirstOrDefaultAsync(i=>i.Id==request.Id);
                await _rules.AboutShouldBeExists(about);
                return _mapper.Map<GetByIdAboutDto>(about);
            }
        }
    }
}
