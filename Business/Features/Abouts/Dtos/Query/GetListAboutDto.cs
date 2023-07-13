using Domain.Entities;

namespace Business.Features.Abouts.Dtos.Query
{
    public class GetListAboutDto
    {
        public IList<About> Abouts { get; set; }
    }
}
