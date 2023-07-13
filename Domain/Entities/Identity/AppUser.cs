using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<About>? Abouts { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<History>? Histories { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public ICollection<Portfolio>? Portfolios { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<SocialMedia>? SocialMedias { get; set; }
        public UserAbout UserAbout { get; set; }
    }
}
