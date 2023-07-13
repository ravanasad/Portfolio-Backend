using Domain.Entities.Files;
using Domain.Entities.Identity;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public string Budget { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SiteLink { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public AppUser User { get; set; }
    }
}
