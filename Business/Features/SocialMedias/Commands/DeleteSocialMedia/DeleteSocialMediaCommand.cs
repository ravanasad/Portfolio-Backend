
using MediatR;
using Business.Features.SocialMedias.Dtos;
using AutoMapper;
using Business.Features.SocialMedias.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand : IRequest<DeleteSocialMediaDto>
    {
        public int Id { get; set; }
        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeleteSocialMediaDto>
        {
            private ISocialMediaDal _socialMediaDal;
            private IMapper _mapper;
            private SocialMediaBusinessRules _rules;

            public DeleteSocialMediaCommandHandler(SocialMediaBusinessRules rules, IMapper mapper = null, ISocialMediaDal socialMediaDal = null)
            {
                _rules = rules;
                _mapper = mapper;
                _socialMediaDal = socialMediaDal;
            }

            public async Task<DeleteSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = await _rules.SocialMediaShouldBeExists(request.Id);
                var deletedSocialMedia = _socialMediaDal.Delete(socialMedia);
                _ = await _socialMediaDal.SaveChangesAsync();
                return _mapper.Map<DeleteSocialMediaDto>(deletedSocialMedia);
            }
        }
    }
}

