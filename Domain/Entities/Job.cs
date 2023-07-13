using Domain.Entities.Identity;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public AppUser User { get; set; }
    }
}
