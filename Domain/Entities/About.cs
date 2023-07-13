using Domain.Entities.Identity;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class About : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public AppUser User { get; set; }
    }
}
