using Domain.Entities.Identity;
using Domain.Entities.Common;


namespace Domain.Entities
{
    public class History : BaseEntity
    {
        public bool Type { get; set; }
        public string Year { get; set; } = string.Empty;
        public string JobName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AppUser User { get; set; }
    }
}
