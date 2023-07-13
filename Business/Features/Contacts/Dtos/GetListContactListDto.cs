using Domain.Entities;

namespace Business.Features.Contacts.Dtos
{
    public class GetListContactDto
    {
        public List<Contact> Contacts { get; set; }
    }
}
