using Business.Features.Files.Dtos;

namespace Business.Features.Files.Models
{
    public class GetListFileModel
    {
        public List<GetByIdFileDto> Files { get; set; }
    }
}
