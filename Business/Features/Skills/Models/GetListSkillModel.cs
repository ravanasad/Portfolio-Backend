using Business.Features.Skills.Dtos;

namespace Business.Features.Skills.Models
{
    public class GetListSkillModel
    {
        public List<GetByIdSkillDto> Skills { get; set; }
    }
}
