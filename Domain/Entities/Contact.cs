using Domain.Entities.Identity;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        //public AppUser User { get; set; }
    }
}
