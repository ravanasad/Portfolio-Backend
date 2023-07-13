
using MediatR;
using Business.Features.SocialMedias.Dtos;
using AutoMapper;
using Business.Features.SocialMedias.Rules;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Business.Features.SocialMedias.Models;

namespace Business.Features.SocialMedias.Queries.GetListSocialMedia
{
    public class GetListSocialMediaQuery : IRequest<GetListSocialMediaModel>
    {
        public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediaQuery, GetListSocialMediaModel>
        {
            private ISocialMediaDal _socialMediaDal;
            private IMapper _mapper;

            public GetListSocialMediaQueryHandler(ISocialMediaDal socialMediaDal, IMapper mapper)
            {
                _socialMediaDal = socialMediaDal;
                _mapper = mapper;
            }

            public async Task<GetListSocialMediaModel> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                List<SocialMedia> socialMedias = await _socialMediaDal.Table.Include(i => i.User).AsNoTracking().ToListAsync();
                GetListSocialMediaDto getListSocialMediaDto = new() { SocialMedias = socialMedias };
                return _mapper.Map<GetListSocialMediaModel>(getListSocialMediaDto);
            }
        }
    }
}

