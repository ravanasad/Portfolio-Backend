using Business.Features.Contacts.Dtos;

namespace Business.Features.Contacts.Models
{
    public class GetListContactModel
    {
        public List<GetByIdContactDto> Contacts { get; set; }
    }
}
