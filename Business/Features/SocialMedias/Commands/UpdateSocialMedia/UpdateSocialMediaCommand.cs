
using MediatR;
using Business.Features.SocialMedias.Dtos;
using AutoMapper;
using Business.Features.SocialMedias.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdateSocialMediaDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SiteLink { get; set; }
        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdateSocialMediaDto>
        {
            private ISocialMediaDal _socialMediaDal;
            private IMapper _mapper;
            private SocialMediaBusinessRules _rules;

            public UpdateSocialMediaCommandHandler(ISocialMediaDal socialMediaDal, IMapper mapper, SocialMediaBusinessRules rules)
            {
                _socialMediaDal = socialMediaDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdateSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = await _rules.SocialMediaShouldBeExists(request.Id);
                socialMedia.SiteLink = request.SiteLink;
                socialMedia.Name = request.Name;
                var updatedSocialMedia = _socialMediaDal.Update(socialMedia);
                _ = await _socialMediaDal.SaveChangesAsync();
                return _mapper.Map<UpdateSocialMediaDto>(updatedSocialMedia);
            }
        }
    }
}

