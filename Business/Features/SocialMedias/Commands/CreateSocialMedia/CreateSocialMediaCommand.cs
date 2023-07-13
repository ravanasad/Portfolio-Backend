using MediatR;
using Business.Features.SocialMedias.Dtos;
using DataAccess.Abstract;
using AutoMapper;
using Business.Features.SocialMedias.Rules;
using Domain.Entities.Identity;
using Domain.Entities;

namespace Business.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommand : IRequest<CreateSocialMediaDto>
    {
        public string Name { get; set; }
        public string SiteLink { get; set; }
        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreateSocialMediaDto>
        {
            private ISocialMediaDal _socialMediaDal;
            private IMapper _mapper;
            private SocialMediaBusinessRules _rules;

            public CreateSocialMediaCommandHandler(ISocialMediaDal socialMediaDal, IMapper mapper, SocialMediaBusinessRules rules)
            {
                _socialMediaDal = socialMediaDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                SocialMedia socialMedia = _mapper.Map<SocialMedia>(request);
                socialMedia.User = user;
                var addedSocialMedia = _socialMediaDal.Add(socialMedia);
                _ = await _socialMediaDal.SaveChangesAsync();
                return _mapper.Map<CreateSocialMediaDto>(addedSocialMedia);
            }
        }
    }
}

