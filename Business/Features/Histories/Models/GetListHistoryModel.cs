using Business.Features.Histories.Dtos;

namespace Business.Features.Histories.Models
{
    public class GetListHistoryModel
    {
        public List<GetByIdHistoryDto> Histories { get; set; }
    }
}
