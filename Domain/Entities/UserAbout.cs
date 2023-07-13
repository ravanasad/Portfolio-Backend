using Domain.Entities.Files;
using Domain.Entities.Identity;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class UserAbout : BaseEntity
    {
        public string? Description { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Fullname { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;
        public string? CvPath { get; set; } = string.Empty;
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
