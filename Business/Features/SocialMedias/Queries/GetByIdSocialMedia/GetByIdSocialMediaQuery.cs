
using MediatR;
using Business.Features.SocialMedias.Dtos;
using DataAccess.Abstract;
using AutoMapper;
using Domain.Entities;
using Business.Features.SocialMedias.Rules;

namespace Business.Features.SocialMedias.Queries.GetByIdSocialMedia
{
    public class GetByIdSocialMediaQuery : IRequest<GetByIdSocialMediaDto>
    {
        public int Id { get; set; }
        public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaDto>
        {
            private SocialMediaBusinessRules _rules;
            private IMapper _mapper;

            public GetByIdSocialMediaQueryHandler(SocialMediaBusinessRules rules, IMapper mapper)
            {
                _rules = rules;
                _mapper = mapper;
            }

            public async Task<GetByIdSocialMediaDto> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = await _rules.SocialMediaShouldBeExists(request.Id);
                return _mapper.Map<GetByIdSocialMediaDto>(socialMedia);
            }
        }
    }
}

