using Business.Features.SocialMedias.Dtos;

namespace Business.Features.SocialMedias.Models
{
    public class GetListSocialMediaModel
    {
        public List<GetByIdSocialMediaDto> SocialMedias { get; set; }
    }
}
