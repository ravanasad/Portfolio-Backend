using Domain.Entities;

namespace Business.Features.Histories.Dtos
{
    public class GetListHistoryDto
    {
        public List<History> Histories { get; set; }
    }
}
