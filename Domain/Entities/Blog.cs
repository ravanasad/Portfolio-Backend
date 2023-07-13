using Domain.Entities.Identity;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Header { get; set; } = string.Empty;
        public string About { get; set; }
        public string Categories { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public AppUser User { get; set; }
    }
}
