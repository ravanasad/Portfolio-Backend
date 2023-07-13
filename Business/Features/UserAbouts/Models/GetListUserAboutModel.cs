using Business.Features.UserAbouts.Dtos;

namespace Business.Features.UserAbouts.Models
{
    public class GetListUserAboutModel
    {
        public List<GetByIdUserAboutDto> UserAbouts { get; set; }
    }
}
