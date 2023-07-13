using AutoMapper;
using Business.Features.UserAbouts.Dtos;
using Business.Features.UserAbouts.Models;
using DataAccess.Abstract;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.UserAbouts.Queries.GetListUserAbout
{
    public class GetListUserAboutQuery : IRequest<GetListUserAboutModel>
    {
        public class GetListUserAboutQueryHandler : IRequestHandler<GetListUserAboutQuery, GetListUserAboutModel>
        {
            private IUserAboutDal _userAboutDal;
            private IMapper _mapper;

            public GetListUserAboutQueryHandler(IUserAboutDal userAboutDal, IMapper mapper)
            {
                _userAboutDal = userAboutDal;
                _mapper = mapper;
            }

            public async Task<GetListUserAboutModel> Handle(GetListUserAboutQuery request, CancellationToken cancellationToken)
            {
                List<UserAbout> userAbouts =await _userAboutDal.Table.Include(i=>i.AppUser).AsNoTracking().ToListAsync();
                GetListUserAboutDto getListUserAboutDto = new() { UserAbouts = userAbouts };
                return _mapper.Map<GetListUserAboutModel>(getListUserAboutDto);
            }
        }
    }
}

