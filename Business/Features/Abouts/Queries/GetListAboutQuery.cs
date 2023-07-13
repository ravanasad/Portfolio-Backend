using AutoMapper;
using Business.Features.Abouts.Dtos.Query;
using Business.Features.Abouts.Models;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Abouts.Queries
{
    public class GetListAboutQuery : IRequest<GetListAboutModel>
    {
        //todo includeler
        public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, GetListAboutModel>
        {
            private IAboutDal _aboutDal;
            private BaseContext _context;
            private IMapper _mapper;

            public GetListAboutQueryHandler(IMapper mapper, IAboutDal aboutDal, BaseContext context)
            {
                _mapper = mapper;
                _aboutDal = aboutDal;
                _context = context;
            }

            public async Task<GetListAboutModel> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
            {
                IList<About> abouts;
                
                abouts = await _aboutDal.Table.Include(i=>i.User).ToListAsync();

                GetListAboutDto getListAboutDto = new() { Abouts= abouts };

                return _mapper.Map<GetListAboutModel>(getListAboutDto);
            }
        }
    }
}
